using MixarTest2.Configs;
using MixarTest2.Models;
using VContainer.Unity;

namespace MixarTest2.Controllers
{
    public class MetroController : IInitializable
    {
        private readonly MetroConfig _metroConfig;
        private readonly MetroModel _metroModel;

        public MetroController(MetroConfig metroConfig, MetroModel metroModel)
        {
            _metroConfig = metroConfig;
            _metroModel = metroModel;
        }

        public void Initialize()
        {
            foreach (var line in _metroConfig.Lines)
            {
                foreach (var stationConfig in line.Stations)
                {
                    _metroModel.AddStation(stationConfig);
                }
            }

            foreach (var line in _metroConfig.Lines)
            {
                var stationsCount = line.Stations.Count;

                for (var i = 0; i < stationsCount; i++)
                {
                    var j = i + 1;

                    if (j >= stationsCount)
                    {
                        if (line.IsCircleLine)
                        {
                            _metroModel.AddRoute(line.Stations[i], line.Stations[0], line.LineId);
                        }

                        break;
                    }

                    _metroModel.AddRoute(line.Stations[i], line.Stations[j], line.LineId);
                }
            }
        }
    }
}