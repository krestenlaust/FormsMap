using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LPSView
{
    public static class QueryDatabase
    {
        private static TcpClient client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <exception cref="SocketException"></exception>
        public static void ConnectDatabase(string hostname, int port)
        {
            client = new TcpClient(hostname, port);
        }

        public static string GetRecentData()
        {
            if (client is null)
            {
                MessageBox.Show("Ikke forbundet til database");
                return null;
            }

            NetworkStream stream = client.GetStream();

            stream.WriteByte(1);

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

            // Example: MAC;enhed.rssi,enhed.rssi,enhed.rssi\n
            foreach (var item in data.Replace("\r", "").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] singleMacDevice = item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                long mac = long.Parse(singleMacDevice[0]);

                if (singleMacDevice.Length == 1)
                {
                    continue;
                }

                DeviceData[mac] = new Dictionary<byte, byte>();

                foreach (string singleStation in singleMacDevice[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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
