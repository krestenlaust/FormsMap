using log4net;
using System.Collections.Generic;
using System.Linq;
using WifiFinderAlgorithm;
using static WifiFinderAlgorithm.WifiFinderAlgorithm;

namespace LPSView
{
    public static class WifiDataThingy
    {
        internal static ILog Log => LogManager.GetLogger(nameof(WifiDataThingy));

        public static IEnumerable<(long, Point)> GetDevicePositions(Dictionary<long, Receiver[]> devices)
        {
            foreach (var item in devices)
            {
                if (item.Value.Length < 3)
                {
                    continue;
                }

                Log.Info("Device position calculations: ");
                foreach (var receiver in item.Value)
                {
                    Log.Info($"- Receiver, Loc: {receiver.coordinate}, Radius: {receiver.signalStrength}");
                }

                Point? intersection = FindDevice(item.Value);
                Log.Info($"- Intersection: {intersection.Value}");

                if (!(intersection is null))
                {
                    yield return (item.Key, intersection.Value);
                }
            }
        }
    }
}
