using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LPSView
{
    public static class QueryDatabase
    {
        private static TcpClient client;

        public static void ConnectDatabase(string hostname, int port)
        {
            client = new TcpClient(hostname, port);
        }

        public static string GetRecentData()
        {
            NetworkStream stream = client.GetStream();

            stream.WriteByte(1);
            Thread.Sleep(100);

            byte[] dataSizeBytes = new byte[sizeof(uint)];
            stream.Read(dataSizeBytes, 0, dataSizeBytes.Length);

            uint dataSize = BitConverter.ToUInt32(dataSizeBytes, 0);

            byte[] incomingData = new byte[dataSize];
            stream.Read(incomingData, 0, incomingData.Length);

            return Encoding.ASCII.GetString(incomingData);
        }

        public static Dictionary<long, Dictionary<byte, byte>> ParseDataString(string data)
        {
            Dictionary<long, Dictionary<byte, byte>> DeviceData = new Dictionary<long, Dictionary<byte, byte>>();

            // MAC;enhed.rssi,enhed.rssi,enhed.rssi\n
            foreach (var item in data.Split('\n'))
            {
                string[] singleMacDevice = item.Split(';');

                long mac = long.Parse(singleMacDevice[0]);
                DeviceData[mac] = new Dictionary<byte, byte>();

                foreach (var singleStation in singleMacDevice[1].Split(','))
                {
                    string[] collection = singleStation.Split('.');

                    byte stationID = byte.Parse(collection[0]);
                    byte rssi = byte.Parse(collection[1]);

                    DeviceData[mac][stationID] = rssi;
                }
            }

            return DeviceData;
        }
    }
}
