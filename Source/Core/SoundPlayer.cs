using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections;

namespace TwitchMonitor.Core
{
    public class SoundPlayer
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        private class SoundPacket
        {
            public int Count { get; set; }
            public SoundPlaySettings Settings { get; set; }
        }

        private BackgroundWorker soundPlayer;
        //private SoundPlaySettings settings;
        private Queue soundQueue;

        public SoundPlayer()
        {
            this.soundPlayer = new BackgroundWorker();
            this.soundPlayer.DoWork += new DoWorkEventHandler(soundPlayer_DoWork);
            this.soundPlayer.WorkerSupportsCancellation = true;
            this.soundQueue = Queue.Synchronized(new Queue());

            //------------------------------------------------------------------
            // Start the listener.
            //------------------------------------------------------------------
            this.soundPlayer.RunWorkerAsync();
        }

        /// <summary>
        /// Stops the sound player's listener. This should be used during application shutdown.
        /// </summary>
        public void Stop()
        {
            if (this.soundPlayer.IsBusy)
            {
                this.soundPlayer.CancelAsync();
            }
        }

        public void ScheduleSound(int count, SoundPlaySettings settings)
        {
            this.soundQueue.Enqueue(new SoundPacket() { Count = count, Settings = settings });

            /*
            if (!this.soundPlayer.IsBusy && settings != null && count > 0)
            {
                this.settings = settings;
                //  Set the WAV sound volume.
                this.SetSoundVolume();
                this.soundPlayer.RunWorkerAsync(count);
            }*/
        }

        /*
        private int GetSoundVolume()
        {
            // By the default set the volume to 0
            uint CurrVol = 0;
            // At this point, CurrVol gets assigned the volume
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            // Calculate the volume
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            // Get the volume on a scale of 1 to 10 (to fit the trackbar)
            return CalcVol / (ushort.MaxValue / 10);
        }
         * */

        private void SetSoundVolume(SoundPlaySettings settings)
        {
            //if (null != this.settings)
            //{
                this.SetSoundVolume(/*this.*/settings.SoundVolume);
            //}
        }

        private void SetSoundVolume(int volume)
        {
            // Calculate the volume that's being set
            //int newVolume = ((ushort.MaxValue / 10) * this.settings.SoundVolume);

            // Set the same volume for both the left and the right channels
            //uint newVolumeAllChannels = (((uint)newVolume & 0x0000ffff) | ((uint)newVolume << 16));

            ushort shortVolume = Convert.ToUInt16(volume);
            ushort newVolume = ushort.MaxValue / 10;
            newVolume *= shortVolume;//((ushort.MaxValue / 10) * volume);

            uint newVolumeAllChannels = newVolume;
            uint temp = newVolume;
            newVolumeAllChannels += temp << 16;

            //int a = 1;
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, newVolumeAllChannels);
        }

        /// <summary>
        /// Plays a sound in a new thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soundPlayer_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!this.soundPlayer.CancellationPending)
            {
                while (this.soundQueue.Count > 0)
                {
                    this.ProcessSoundPacket(this.soundQueue.Dequeue() as SoundPacket);
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Processes a queued sound packet.
        /// </summary>
        /// <param name="packet"></param>
        private void ProcessSoundPacket(SoundPacket packet)
        {
            //------------------------------------------------------------------
            //  Cache off the settings to use before we start playing sounds.
            //------------------------------------------------------------------
            //int count = (int)e.Argument;
            PlaySoundType soundType = packet.Settings.PlaySoundType;// this.settings.PlaySoundType;
            string soundDirectory = packet.Settings.SoundDirectory;// this.settings.SoundDirectory;
            string soundFile = packet.Settings.SoundFile;// this.settings.SoundFile;
            this.SetSoundVolume(packet.Settings);

            if (soundType == PlaySoundType.FromDirectory)
            {
                if (!string.IsNullOrEmpty(soundDirectory) && Directory.Exists(soundDirectory))
                {
                    try
                    {
                        for (int i = 0; i < packet.Count; i++)
                        {
                            List<string> fileList = new List<string>();
                            foreach (string file in Directory.EnumerateFiles(soundDirectory, "*.*"))
                            {
                                FileInfo info = new FileInfo(file);
                                switch (info.Extension)
                                {
                                    case ".wav":
                                        fileList.Add(file);
                                        break;
                                }
                            }
                            Random random = new Random();
                            this.PlaySynchronousSound(fileList[random.Next(fileList.Count - 1)]);
                        }
                    }
                    catch (Exception) { /*Ignore any exceptions and continue.*/ }
                }
            }
            else if (soundType == PlaySoundType.FromFile)
            {
                try
                {
                    if (File.Exists(soundFile))
                    {
                        for (int i = 0; i < packet.Count; i++)
                        {
                            this.PlaySynchronousSound(soundFile);
                        }
                    }
                }
                catch (Exception) { /*Ignore any exceptions.*/ }
            }
        }

        /// <summary>
        /// Plays the specified sound file.
        /// </summary>
        /// <param name="file"></param>
        private void PlayAsynchronousSound(string file)
        {
            ThreadPool.QueueUserWorkItem(this.PlayThreadedSound, file);
        }

        private void PlayThreadedSound(Object objectState)
        {
            string file = objectState as string;
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(file))
            {
                player.Play();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void PlaySynchronousSound(string file)
        {
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(file))
            {
                player.PlaySync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volume"></param>
        public void PlaySample(int volume)
        {
            this.SetSoundVolume(volume);
            this.PlayAsynchronousSound(@"C:\Windows\Media\Windows Ding.wav");
        }
    }
}
