using System.Collections.Generic;
using System.Linq;
using MixarTest2.Views;

namespace MixarTest2.Models
{
    public class SchemeModel
    {
        public List<string> StationIds
        {
            get
            {
                if (_stationsIds == null)
                {
                    _stationsIds = new List<string>();

                    _stationsIds = Stations.Keys.ToList();
                }

                return _stationsIds;
            }
        }

        public Dictionary<string, StationView> Stations { get; } = new Dictionary<string, StationView>();

        private List<string> _stationsIds;

        public void AddStation(string stationId, StationView stationView)
        {
            Stations.Add(stationId, stationView);
        }
    }
}