using System.Collections.Generic;
using System.Linq;
using WifiFinderAlgorithm;
using static WifiFinderAlgorithm.WifiFinderAlgorithm;

namespace LPSView
{
    public static class WifiDataThingy
    {
        public static IEnumerable<(long, Point)> GetDevicePositions(Dictionary<long, Dictionary<byte, byte>> devices, params Coordinate[] stations)
        {
            foreach (var item in devices)
            {
                if (item.Value.Count < 3)
                {
                    continue;
                }

                Point? intersection = FindDevice(
                    new Receiver(stations[0], item.Value.ElementAt(0).Key),
                    new Receiver(stations[1], item.Value.ElementAt(1).Key),
                    new Receiver(stations[2], item.Value.ElementAt(2).Key));

                if (!(intersection is null))
                {
                    yield return (item.Key, intersection.Value);
                }
            }
        }
    }
}
