using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TwitchMonitor.Core.Types;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace TwitchMonitor.Core
{
    public class ServerPings
    {
        private static readonly int RtmpPort = 1935;
        private static readonly int PingWaitTime = 5000;
        private Engine engine;

        public ServerPingsDataTable ServerListTable { get; private set; }

        public IList<IngestJson> IngestServers { get; private set; }

        public ServerPings(Engine engine)
        {
            this.engine = engine;
            this.IngestServers = new List<IngestJson>();
            this.ServerListTable = new ServerPingsDataTable();
        }

        /// <summary>
        /// Refreshes the list of servers.
        /// </summary>
        public void InitializeServerList(BackgroundWorker worker)
        {
            string connectionUri = "https://api.twitch.tv/kraken/ingests";
            this.ServerListTable = new ServerPingsDataTable();

            WebRequest request = WebRequest.Create(connectionUri);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    IngestsJsonPacket responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<IngestsJsonPacket>(reader.ReadToEnd());

                    //--------------------------------------------------------------
                    //  If the engine has a cancellation pending, stop.
                    //--------------------------------------------------------------
                    if (Engine.CancellationPending) { return; }

                    this.IngestServers.Clear();
                    this.IngestServers = responseJson.Ingests;

                    //----------------------------------------------------------
                    //  Reset the table containing the view-friendly info
                    //  for the servers.
                    //----------------------------------------------------------
                    this.ServerListTable.Clear();
                    foreach (IngestJson ingest in this.IngestServers)
                    {
                        this.ServerListTable.AddNewIngest(ingest);
                    }
                }

                this.RefreshPingTimes(worker);
            }
            catch (Exception ex)
            {
                worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = ex.Message });
            }
        }

        /// <summary>
        /// Refreshes the list of ping times for each server.
        /// </summary>
        public void RefreshPingTimes(BackgroundWorker worker)
        {
            try
            {
                foreach (IngestJson ingest in this.IngestServers)
                {
                    //--------------------------------------------------------------
                    //  If the engine has a cancellation pending, stop.
                    //--------------------------------------------------------------
                    if (Engine.CancellationPending) { return; }

                    //--------------------------------------------------------------
                    //  Setup the objects needed to ping the server.
                    //--------------------------------------------------------------
                    TcpClient tcpClient = new TcpClient();
                    string host = ingest.UrlTemplate.Split('/')[2];
                    IPHostEntry hostEntry = Dns.GetHostEntry(host);
                    Stopwatch timer = new Stopwatch();
                    ManualResetEvent resetEvent = new ManualResetEvent(false);

                    //--------------------------------------------------------------
                    //  Ping the server.
                    //--------------------------------------------------------------
                    timer.Start();
                    tcpClient.BeginConnect(hostEntry.AddressList[0], ServerPings.RtmpPort, new AsyncCallback(ServerPings.ConnectCallback), resetEvent);
                    bool signalReceived = resetEvent.WaitOne(ServerPings.PingWaitTime);
                    timer.Stop();

                    if (signalReceived)
                    {
                        this.ServerListTable.UpdatePingTime(ingest.Name, timer.ElapsedMilliseconds);
                    }
                }
            }
            catch (Exception ex)
            {
                worker.ReportProgress(0, new ThreadMessage() { Status = ThreadMessageStatus.Error, Message = ex.Message });
            }
        }

        /// <summary>
        /// Callback used by the TCP connection that checks the state of the connection.
        /// </summary>
        /// <param name="result">The asynchronous result object that indicates whether or not the connection has been established.</param>
        public static void ConnectCallback(IAsyncResult result)
        {
            //------------------------------------------------------------------
            //  If connection is complete, signal the event so the thread
            //  making the connection knows to stop and calculate the time
            //  taken.
            //------------------------------------------------------------------
            if (result.IsCompleted || Engine.CancellationPending)
            {
                ((EventWaitHandle)result.AsyncState).Set();
            }
        }

        private void GetServerPingTimes()
        {
            
        }
    }
}
