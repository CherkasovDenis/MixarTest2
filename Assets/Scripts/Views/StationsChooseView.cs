using TMPro;
using UnityEngine;

namespace MixarTest2.Views
{
    public class StationsChooseView : MonoBehaviour
    {
        public TMP_Dropdown StartStationDropdown => _startStationDropdown;

        public TMP_Dropdown FinishStationDropdown => _finishStationDropdown;

        [SerializeField]
        private TMP_Dropdown _startStationDropdown;

        [SerializeField]
        private TMP_Dropdown _finishStationDropdown;
    }
}