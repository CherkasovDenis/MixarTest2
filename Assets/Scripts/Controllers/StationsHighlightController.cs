using System;
using System.Linq;
using MixarTest2.Models;
using MixarTest2.Views;
using VContainer.Unity;

namespace MixarTest2.Controllers
{
    public class StationsHighlightController : IStartable, IDisposable
    {
        private readonly SchemeModel _schemeModel;
        private readonly StationsChooseModel _stationsChooseModel;

        public StationsHighlightController(SchemeModel schemeModel, StationsChooseModel stationsChooseModel)
        {
            _schemeModel = schemeModel;
            _stationsChooseModel = stationsChooseModel;
        }

        public void Start()
        {
            _stationsChooseModel.PathUpdated += EnableHighlight;
            _stationsChooseModel.Error += DisableHighlight;
        }

        public void Dispose()
        {
            _stationsChooseModel.PathUpdated -= EnableHighlight;
            _stationsChooseModel.Error -= DisableHighlight;
        }

        private void EnableHighlight(PathInfo pathInfo)
        {
            DisableHighlight();

            EnableHighlight(_schemeModel.Stations[pathInfo.Path.First().Id]);
            EnableHighlight(_schemeModel.Stations[pathInfo.Path.Last().Id]);
        }

        private void EnableHighlight(StationView stationView) => stationView.EnableHighlight();

        private void DisableHighlight(string _) => DisableHighlight();

        private void DisableHighlight()
        {
            foreach (var station in _schemeModel.Stations)
            {
                station.Value.DisableHighlight();
            }
        }
    }
}