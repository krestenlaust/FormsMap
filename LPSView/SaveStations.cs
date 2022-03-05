using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LPSView
{
    public static class SaveStations
    {
        private static IEnumerable<StoredStation> loadedStations = null;

        public static IEnumerable<StoredStation> GetStoredStations()
        {
            if (loadedStations is null)
            {
                loadedStations = LoadStationsFromSettings();
            }

            return loadedStations;
        }

        public static void StoreStation(StoredStation station)
        {
            IEnumerable<StoredStation> storedStations = GetStoredStations();

            // ignore elements with same ID.
            var storedStationsNew = (from s in storedStations
                                    where s.ID != station.ID
                                    select s).Append(station);

            ClearAndStoreStations(storedStationsNew);
        }

        public static void ClearStoredStations()
        {
            Properties.Settings.Default.Stations.Clear();
            loadedStations = null;
        }

        private static IEnumerable<StoredStation> LoadStationsFromSettings()
        {
            foreach (var item in Properties.Settings.Default.Stations)
            {
                yield return StoredStation.DeserializeStation(item);
            }
        }

        public static void ClearAndStoreStations(IEnumerable<StoredStation> stations)
        {
            var stationStrings = Properties.Settings.Default.Stations;
            stationStrings.Clear();
            loadedStations = stations;

            foreach (var item in stations)
            {
                stationStrings.Add(item.ToString());
            }

            Properties.Settings.Default.Save();
        }

        public struct StoredStation
        {
            public int X;
            public int Y;
            public byte ID;
            public string StationName;

            public StoredStation(int x, int y, byte id, string stationName)
            {
                X = x;
                Y = y;
                ID = id;
                StationName = stationName;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(X);
                sb.Append(';');
                sb.Append(Y);
                sb.Append(';');
                sb.Append(ID);
                sb.Append(';');
                sb.Append(StationName);

                return sb.ToString();
            }

            public static StoredStation DeserializeStation(string station)
            {
                if (station is null)
                {
                    throw new ArgumentNullException(nameof(station));
                }

                string[] splittedString = station.Split(new char[] { ';' }, 4);
                int x, y;
                x = int.Parse(splittedString[0]);
                y = int.Parse(splittedString[1]);

                byte id;
                id = byte.Parse(splittedString[2]);

                string stationName = splittedString[3];

                return new StoredStation(x, y, id, stationName);
            }
        }
    }
}
