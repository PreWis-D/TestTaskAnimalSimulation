using UnityEngine;

namespace SpawnerExample
{
    public class SpawnZoneInitializer : MonoBehaviour
    {
        [SerializeField] private int _step;
        [SerializeField] private Vector2Int _spawnZoneSize;
        [SerializeField] private SpawnZone _spawnZone;

        private int _minValue = 1;
        private Vector2Int _currentSize;
        private float _offset = 0.5f;

        public SpawnZone SpawnZone => _spawnZone;

        private void Awake()
        {
            _currentSize = _spawnZoneSize;

            if (_step <= 0)
                _step = _minValue;

            Init();
        }

        public void ChangeSize()
        {
            _spawnZoneSize = new Vector2Int(_currentSize.x, _currentSize.y);
            _currentSize = _spawnZoneSize;
            Init();
        }

        private void Init()
        {
            _spawnZone.Initialize(_spawnZoneSize, _step, _offset);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 1f);
            Vector2 offset = new Vector2((_spawnZoneSize.x - _step) * _offset, (_spawnZoneSize.y - _step) * _offset);

            for (int y = 0; y < _spawnZoneSize.y; y += _step)
            {
                for (int x = 0; x < _spawnZoneSize.x; x += _step)
                {
                    Gizmos.DrawSphere(new Vector3(x - offset.x, 0, y - offset.y), 0.25f);
                }
            }
        }
#endif
    }
}