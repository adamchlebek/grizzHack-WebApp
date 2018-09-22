using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace grizzHack_WebApp
{
    internal class tcpClient
    {
        private TcpClient client = new TcpClient();
        private String ip = "35.237.232.103";
        public List<string> recievedData = new List<string>();
        private Boolean running = true;

        private int port = 7865;

        public void start()
        {
            client.Connect(ip, port);
        }

        public void sendData(String data)
        {
            StreamWriter sw = new StreamWriter(client.GetStream());
            sw.WriteLine(data);
            sw.FlushAsync();

            Thread recieveThread = new Thread(recievePackets);
            recieveThread.Start();
        }

        public void recievePackets()
        {
            using (StreamReader sr = new StreamReader(client.GetStream()))
            {
                while (running)
                {
                    String data = sr.ReadLine();
                    if (data != "")
                    {
                        recievedData.Add(data);
                    }
                }
            }
        }
    }
}