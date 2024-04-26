using UnityEngine;

namespace MixarTest2.Configs
{
    [CreateAssetMenu(fileName = nameof(StationConfig),
        menuName = Constants.ConfigMenuPath + nameof(StationConfig))]
    public class StationConfig : ScriptableObject
    {
        public string Id => _id;

        public Vector2 Position => _position;

        [SerializeField]
        private string _id;

        [SerializeField]
        private Vector2 _position;

        public void SetPosition(Vector3 pos)
        {
            _position = pos;
        }
    }
}