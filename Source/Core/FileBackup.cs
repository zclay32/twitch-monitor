using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TwitchMonitor.Core
{
    public class FileBackup
    {
        public static readonly string BackupDirName = "backup";

        private Engine engine;
        private string backupDir;

        public FileBackup(Engine engine)
        {
            this.engine = engine;
            this.backupDir = Path.Combine(Engine.CacheDirectory, FileBackup.BackupDirName);

            if (!Directory.Exists(this.backupDir))
            {
                Directory.CreateDirectory(this.backupDir);
            }
        }

        /// <summary>
        /// Backs up the specified file to the backup directory.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filesToKeep"></param>
        /// <param name="profile"></param>
        public void BackupFile(string file, int filesToKeep, string profile = "")
        {
            //------------------------------------------------------------------
            //  Don't backup the file if it doesn't exist.
            //------------------------------------------------------------------
            if (!File.Exists(file))
            {
                return;
            }

            FileInfo fileInfo = new FileInfo(file);
            string targetDir = Path.Combine(this.backupDir, profile);
            string filename = fileInfo.Name.Split(new string[] { fileInfo.Extension }, StringSplitOptions.RemoveEmptyEntries)[0];

            try
            {
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                //--------------------------------------------------------------
                //  Iterate over the target directory and remove any extra files.
                //--------------------------------------------------------------
                IEnumerable<string> bakcupFiles = Directory.EnumerateFiles(targetDir, filename + "*" + fileInfo.Extension);
                if (bakcupFiles.Count() > filesToKeep)
                {
                    //----------------------------------------------------------
                    //  Find the matching file with the earliest timestamp and
                    //  remove it.
                    //----------------------------------------------------------
                    DateTime earliestTime = DateTime.MinValue;
                    string fileToRemove = string.Empty;
                    foreach (string backupFile in bakcupFiles)
                    {
                        FileInfo backupFileInfo = new FileInfo(backupFile);
                        if (string.IsNullOrEmpty(fileToRemove) || backupFileInfo.LastWriteTime < earliestTime)
                        {
                            earliestTime = backupFileInfo.LastWriteTime;
                            fileToRemove = backupFile;
                        }
                    }

                    if (File.Exists(fileToRemove))
                    {
                        File.Delete(fileToRemove);
                    }
                }

                //--------------------------------------------------------------
                //  Copy the new file.
                //--------------------------------------------------------------
                string dateString = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string newFile = string.Format("{0}_{1}{2}", filename, dateString, fileInfo.Extension);
                File.Copy(file, Path.Combine(targetDir, newFile));
            }
            catch (Exception)
            {
                // Ignore any exceptions for now.
            }
        }
    }
}
