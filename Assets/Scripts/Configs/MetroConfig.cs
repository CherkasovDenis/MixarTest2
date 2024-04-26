using System;
using System.Collections.Generic;
using UnityEngine;

namespace MixarTest2.Configs
{
    [CreateAssetMenu(fileName = nameof(MetroConfig),
        menuName = Constants.ConfigMenuPath + nameof(MetroConfig))]
    public class MetroConfig : ScriptableObject
    {
        public List<Line> Lines => _lines;

        [SerializeField]
        private List<Line> _lines;
    }

    [Serializable]
    public class Line
    {
        public string LineId => _lineId;

        public Gradient LineColor => _lineColor;

        public bool IsCircleLine => _isCircleLine;

        public List<StationConfig> Stations => _stations;

        [SerializeField]
        private string _lineId;

        [SerializeField]
        private Gradient _lineColor;

        [SerializeField]
        private bool _isCircleLine;

        [SerializeField]
        private List<StationConfig> _stations;
    }
}