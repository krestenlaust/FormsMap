using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using WifiFinderAlgorithm;
using static WifiFinderAlgorithm.WifiFinderAlgorithm;

namespace LPSView
{
    public static class WifiDataThingy
    {
        internal static ILog Log => LogManager.GetLogger(nameof(WifiDataThingy));

        public static IEnumerable<(string, Point)> GetDevicePositions(Dictionary<long, Receiver[]> devices)
        {
            foreach (var item in devices)
            {
                if (item.Value.Length < 3)
                {
                    continue;
                }

                Log.Info($"Device position calculations {item.Key}: ");
                foreach (var receiver in item.Value)
                {
                    Log.Info($"- Receiver, Loc: ({receiver.coordinate.x}, {receiver.coordinate.y}), Radius: {receiver.signalStrength}");
                }

                Point? intersection = FindDevice(item.Value);
                Log.Info($"- Intersection: {intersection}");

                if (!(intersection is null))
                {
                    yield return (string.Join(":", BitConverter.GetBytes(item.Key).Reverse().Select(b => b.ToString("X2"))).Substring(6), intersection.Value);
                }
            }
        }
    }
}
