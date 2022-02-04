using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LPSView
{
    public static class QueryDatabase
    {
        private static List<TcpClient> clients = new List<TcpClient>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <exception cref="SocketException"></exception>
        public static void ConnectDatabase(string hostname, int port)
        {
            TcpClient client = new TcpClient(hostname, port);
            clients.Add(client);
        }

        public static string GetRecentData()
        {
            foreach (var client in clients)
            {
                if (client?.Connected != true)
                {
                    MessageBox.Show("Ikke forbundet til database");
                    return null;
                }

                NetworkStream stream = client.GetStream();

                stream.WriteByte(1);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var client in clients)
            {
                if (client?.Connected != true)
                {
                    MessageBox.Show("Ikke forbundet til database");
                    return null;
                }

                NetworkStream stream = client.GetStream();

                byte[] dataSizeBytes = new byte[sizeof(uint)];
                stream.Read(dataSizeBytes, 0, dataSizeBytes.Length);

                uint dataSize = BitConverter.ToUInt32(dataSizeBytes, 0);

                byte[] incomingData = new byte[dataSize];
                stream.Read(incomingData, 0, incomingData.Length);

                sb.AppendLine(Encoding.ASCII.GetString(incomingData));
            }

            return sb.ToString();
        }

        public static Dictionary<long, Dictionary<byte, byte>> ParseDataString(string data)
        {
            Dictionary<long, Dictionary<byte, byte>> DeviceData = new Dictionary<long, Dictionary<byte, byte>>();

            // Example: MAC;enhed.rssi,enhed.rssi,enhed.rssi\n
            foreach (var item in data.Replace("\r", "").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] singleMacDevice = item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                // MAC is hexadecimal (without colons)
                long mac = Convert.ToInt64(singleMacDevice[0], 16);

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
