using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace LPSView
{
    public static class QueryDatabase
    {
        private static readonly List<TcpClient> clients = new List<TcpClient>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <exception cref="SocketException"></exception>
        public static void ConnectDatabase(string hostname, int port)
        {
            try
            {
                TcpClient client = new TcpClient(hostname, port);
                clients.Add(client);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Cannot connecct to database");
            }
        }

        public static string GetRecentData()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var client in clients)
            {
                if (client?.Connected != true)
                {
                    MessageBox.Show("Ikke forbundet til database");
                    return string.Empty;
                }

                NetworkStream stream = client.GetStream();

                while (stream.DataAvailable)
                {
                    byte[] dataSizeBytes = new byte[sizeof(uint)];
                    stream.Read(dataSizeBytes, 0, dataSizeBytes.Length);

                    uint dataSize = BitConverter.ToUInt32(dataSizeBytes, 0);

                    byte[] incomingData = new byte[dataSize];
                    stream.Read(incomingData, 0, incomingData.Length);

                    sb.Append(Encoding.ASCII.GetString(incomingData));
                }
            }

            return sb.ToString();
        }

        public static Dictionary<long, Dictionary<byte, byte>> ParseDataString(string data)
        {
            Dictionary<long, Dictionary<byte, byte>> deviceData = new Dictionary<long, Dictionary<byte, byte>>();

            // Example: MAC;enhed.rssi,enhed.rssi,enhed.rssi\n
            foreach (var item in data.Replace("\r", "").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] singleMacDevice;
                long mac;

                try
                {
                    singleMacDevice = item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    // MAC is hexadecimal (without colons)
                    mac = Convert.ToInt64(singleMacDevice[0]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Weird glitch: " + ex);
                    continue;
                }
                
                if (singleMacDevice.Length == 1)
                {
                    // Empty
                    continue;
                }

                if (!deviceData.TryGetValue(mac, out Dictionary<byte, byte> deviceDataStations))
                {
                    deviceDataStations = new Dictionary<byte, byte>();
                    deviceData[mac] = deviceDataStations;
                }

                foreach (string singleStation in singleMacDevice[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] collection = singleStation.Split('.');

                    byte stationID = byte.Parse(collection[0]);
                    byte rssi = byte.Parse(collection[1]);

                    deviceDataStations[stationID] = rssi;
                }
            }

            return deviceData;
        }
    }
}
