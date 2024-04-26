using System;
using System.Collections.Generic;
using MixarTest2.Models;
using MixarTest2.Services;
using MixarTest2.Views;
using TMPro;
using VContainer.Unity;

namespace MixarTest2.Controllers
{
    public class StationsChooseController : IStartable, IDisposable
    {
        private readonly TMP_Dropdown _startStationDropdown;
        private readonly TMP_Dropdown _finishStationDropdown;
        private readonly StationsChooseModel _stationsChooseModel;
        private readonly SchemeModel _schemeModel;
        private readonly PathFinderService _pathFinderService;

        public StationsChooseController(StationsChooseView stationsChooseView, StationsChooseModel stationsChooseModel,
            SchemeModel schemeModel, PathFinderService pathFinderService)
        {
            _startStationDropdown = stationsChooseView.StartStationDropdown;
            _finishStationDropdown = stationsChooseView.FinishStationDropdown;
            _stationsChooseModel = stationsChooseModel;
            _schemeModel = schemeModel;
            _pathFinderService = pathFinderService;
        }

        public void Start()
        {
            var options = _schemeModel.StationIds;

            InitializeDropdown(_startStationDropdown, options);
            InitializeDropdown(_finishStationDropdown, options);
        }

        public void Dispose()
        {
            _startStationDropdown.onValueChanged.RemoveListener(StationDropdownChanged);
            _finishStationDropdown.onValueChanged.RemoveListener(StationDropdownChanged);
        }

        private void InitializeDropdown(TMP_Dropdown dropdown, List<string> options)
        {
            dropdown.onValueChanged.AddListener(StationDropdownChanged);
            dropdown.AddOptions(options);
        }

        private void StationDropdownChanged(int _)
        {
            var stationsIds = _schemeModel.StationIds;

            var startStationId = stationsIds[_startStationDropdown.value];
            var finishStationId = stationsIds[_finishStationDropdown.value];

            if (startStationId == finishStationId)
            {
                _stationsChooseModel.OnError(Constants.NotUniqueStationsError);
                return;
            }

            var path = _pathFinderService.GetShortestPath(startStationId, finishStationId);

            _stationsChooseModel.OnPathUpdated(path);
        }
    }
}