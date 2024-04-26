using System.Collections.Generic;
using System.Linq;
using MixarTest2.Models;

namespace MixarTest2.Services
{
    public class PathFinderService
    {
        private readonly MetroModel _metroModel;

        private readonly List<StationInfo> _stationInfos;

        public PathFinderService(MetroModel metroModel)
        {
            _metroModel = metroModel;
            _stationInfos = new List<StationInfo>();
        }

        public PathInfo GetShortestPath(string startStationId, string finishStationId)
        {
            if (_stationInfos.Count == 0)
            {
                foreach (var station in _metroModel.Stations)
                {
                    _stationInfos.Add(new StationInfo(station));
                }
            }
            else
            {
                foreach (var stationInfo in _stationInfos)
                {
                    stationInfo.Reset();
                }
            }

            var startStationInfo = GetStationInfo(startStationId);
            startStationInfo.PathLength = 0;
            startStationInfo.TransferCount = 0;
            startStationInfo.IsStartStation = true;

            var finishStationInfo = GetStationInfo(finishStationId);

            while (true)
            {
                var current = FindUnvisitedStationWithMinPathLength();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertex(current);
            }

            return GetPath(startStationInfo, finishStationInfo);
        }

        private StationInfo GetStationInfo(Station station)
        {
            return GetStationInfo(station.Id);
        }

        private StationInfo GetStationInfo(string stationId)
        {
            foreach (var stationInfo in _stationInfos)
            {
                if (stationInfo.Station.Id == stationId)
                {
                    return stationInfo;
                }
            }

            return null;
        }

        private StationInfo FindUnvisitedStationWithMinPathLength()
        {
            var minPathLength = int.MaxValue;
            var minTransferCount = int.MaxValue;
            StationInfo minStationInfo = null;

            foreach (var stationInfo in _stationInfos.Where(stationInfo => stationInfo.IsUnvisited))
            {
                if (stationInfo.PathLength < minPathLength ||
                    (stationInfo.PathLength == minPathLength && stationInfo.TransferCount < minTransferCount))
                {
                    minStationInfo = stationInfo;
                    minPathLength = stationInfo.PathLength;
                    minTransferCount = stationInfo.TransferCount;
                }
            }

            return minStationInfo;
        }

        private void SetSumToNextVertex(StationInfo stationInfo)
        {
            stationInfo.IsUnvisited = false;

            foreach (var route in stationInfo.Station.Routes)
            {
                var nextStationInfo = GetStationInfo(route.ConnectedStation);
                var sum = stationInfo.PathLength + 1;
                var transferCount = stationInfo.IsStartStation
                    ? 0
                    : stationInfo.TransferCount + (stationInfo.LineId == route.LineId ? 0 : 1);

                if (sum < nextStationInfo.PathLength)
                {
                    nextStationInfo.PathLength = sum;
                    nextStationInfo.TransferCount = transferCount;
                    nextStationInfo.LineId = route.LineId;
                    nextStationInfo.PreviousStation = stationInfo.Station;
                }
            }
        }

        private PathInfo GetPath(StationInfo startStationInfo, StationInfo finishStationInfo)
        {
            var path = new List<Station>();

            var transferCount = finishStationInfo.TransferCount;

            var startStation = startStationInfo.Station;
            var finishStation = finishStationInfo.Station;

            path.Add(finishStation);

            while (startStation != finishStation)
            {
                finishStation = finishStationInfo.PreviousStation;

                finishStationInfo = GetStationInfo(finishStation);

                path.Add(finishStation);
            }

            path.Reverse();

            return new PathInfo(path, transferCount);
        }
    }
}