using System;
using System.Linq;
using MixarTest2.Models;
using UnityEngine;
using VContainer.Unity;

namespace MixarTest2.Controllers
{
    public class PathDisplayController : IStartable, IDisposable
    {
        private readonly LineRenderer _pathLineRenderer;
        private readonly StationsChooseModel _stationsChooseModel;
        private readonly SchemeModel _schemeModel;

        public PathDisplayController(LineRenderer pathLineRenderer, StationsChooseModel stationsChooseModel,
            SchemeModel schemeModel)
        {
            _pathLineRenderer = pathLineRenderer;
            _stationsChooseModel = stationsChooseModel;
            _schemeModel = schemeModel;
        }

        public void Start()
        {
            _stationsChooseModel.PathUpdated += UpdatePathDisplay;
            _stationsChooseModel.Error += DisablePathDisplay;
        }

        public void Dispose()
        {
            _stationsChooseModel.PathUpdated -= UpdatePathDisplay;
            _stationsChooseModel.Error -= DisablePathDisplay;
        }

        private void UpdatePathDisplay(PathInfo pathInfo)
        {
            var pathPoints = pathInfo.Path
                .Select(station => _schemeModel.Stations[station.Id].transform.position).ToArray();

            _pathLineRenderer.positionCount = pathPoints.Length;
            _pathLineRenderer.SetPositions(pathPoints);
        }

        private void DisablePathDisplay(string _)
        {
            _pathLineRenderer.positionCount = 0;
        }
    }
}