using TMPro;
using UnityEngine;

namespace MixarTest2.Views
{
    public class PathInfoView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _pathText;

        [SerializeField]
        private TMP_Text _transfersText;

        public void SetPathText(string path)
        {
            _pathText.text = path;
        }

        public void SetTransfersCount(string transferCount)
        {
            _transfersText.text = transferCount;
        }

        public void SetErrorText(string error)
        {
            _transfersText.text = "0";
            _pathText.text = error;
        }
    }
}