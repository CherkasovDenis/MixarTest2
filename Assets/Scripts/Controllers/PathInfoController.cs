using System;
using System.Linq;
using MixarTest2.Models;
using MixarTest2.Views;
using VContainer.Unity;

namespace MixarTest2.Controllers
{
    public class PathInfoController : IStartable, IDisposable
    {
        private readonly PathInfoView _pathInfoView;
        private readonly StationsChooseModel _stationsChooseModel;

        public PathInfoController(PathInfoView pathInfoView, StationsChooseModel stationsChooseModel)
        {
            _pathInfoView = pathInfoView;
            _stationsChooseModel = stationsChooseModel;
        }

        public void Start()
        {
            _stationsChooseModel.PathUpdated += UpdatePathInfo;
            _stationsChooseModel.Error += UpdateErrorText;
        }

        public void Dispose()
        {
            _stationsChooseModel.PathUpdated -= UpdatePathInfo;
            _stationsChooseModel.Error -= UpdateErrorText;
        }

        private void UpdatePathInfo(PathInfo pathInfo)
        {
            var path = pathInfo.Path.Aggregate("",
                (x, station) => x + station.Id + Constants.ArrowSymbol);

            path = path.Substring(0, path.Length - Constants.ArrowSymbol.Length);

            _pathInfoView.SetPathText(path);
            _pathInfoView.SetTransfersCount(pathInfo.TransferCount.ToString());
        }

        private void UpdateErrorText(string error)
        {
            _pathInfoView.SetErrorText(error);
        }
    }
}