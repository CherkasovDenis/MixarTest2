using System.Collections.Generic;
using MixarTest2.Configs;
using MixarTest2.Models;
using MixarTest2.Views;
using UnityEngine;
using VContainer.Unity;

namespace MixarTest2.Controllers
{
    public class SchemeController : IStartable
    {
        private readonly MetroConfig _metroConfig;
        private readonly StationView _stationPrefab;
        private readonly LineRenderer _linePrefab;
        private readonly Transform _schemeParent;
        private readonly SchemeModel _schemeModel;

        public SchemeController(MetroConfig metroConfig, StationView stationPrefab, LineRenderer linePrefab,
            Transform schemeParent, SchemeModel schemeModel)
        {
            _metroConfig = metroConfig;
            _stationPrefab = stationPrefab;
            _linePrefab = linePrefab;
            _schemeParent = schemeParent;
            _schemeModel = schemeModel;
        }

        public void Start()
        {
            foreach (var line in _metroConfig.Lines)
            {
                var stationPositions = new List<Vector3>();

                foreach (var stationConfig in line.Stations)
                {
                    var stationPosition = stationConfig.Position;

                    var stationId = stationConfig.Id;

                    if (!_schemeModel.Stations.TryGetValue(stationId, out var stationView))
                    {
                        stationView = SpawnStation(stationId, stationPosition);
                        _schemeModel.AddStation(stationId, stationView);
                    }

                    stationPositions.Add(stationView.transform.position);
                }

                SpawnLine(line.LineColor, stationPositions, line.IsCircleLine);
            }
        }

        private StationView SpawnStation(string stationId, Vector2 position)
        {
            var station = Object.Instantiate(_stationPrefab, _schemeParent);

            station.transform.localPosition = position;
            station.SetStationId(stationId);

            return station;
        }

        private void SpawnLine(Gradient lineColor, List<Vector3> positions, bool isCircleLine)
        {
            var lineRenderer = Object.Instantiate(_linePrefab, _schemeParent);

            lineRenderer.colorGradient = lineColor;
            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
            lineRenderer.loop = isCircleLine;
        }
    }
}