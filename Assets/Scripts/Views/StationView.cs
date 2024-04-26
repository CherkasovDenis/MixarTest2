using TMPro;
using UnityEngine;

namespace MixarTest2.Views
{
    public class StationView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _stationIdText;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Color _normalColor;

        [SerializeField]
        private Color _highlightedColor;

        public void SetStationId(string stationId)
        {
            _stationIdText.text = stationId;
        }

        public void EnableHighlight()
        {
            _spriteRenderer.color = _highlightedColor;
        }

        public void DisableHighlight()
        {
            _spriteRenderer.color = _normalColor;
        }
    }
}