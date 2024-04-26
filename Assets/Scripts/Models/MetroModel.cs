using System.Collections.Generic;
using System.Linq;
using MixarTest2.Configs;

namespace MixarTest2.Models
{
    public class MetroModel
    {
        public List<Station> Stations { get; } = new List<Station>();

        public void AddStation(StationConfig stationConfig)
        {
            if (Stations.Any(x => x.Id == stationConfig.Id))
            {
                return;
            }

            Stations.Add(new Station(stationConfig.Id));
        }

        public void AddRoute(StationConfig firstStationConfig, StationConfig secondStationConfig, string lineId)
        {
            if (TryGetStation(firstStationConfig, out var firstStation) &&
                TryGetStation(secondStationConfig, out var secondStation))
            {
                firstStation.AddRoute(new Route(secondStation, lineId));
                secondStation.AddRoute(new Route(firstStation, lineId));
            }
        }

        public bool TryGetStation(StationConfig stationConfig, out Station station)
        {
            foreach (var s in Stations)
            {
                if (s.Id == stationConfig.Id)
                {
                    station = s;
                    return true;
                }
            }

            station = null;
            return false;
        }
    }
}