using System.Collections.Generic;
using UnityEngine;

namespace SpawnerExample
{
    public class SpawnZone : MonoBehaviour
    {
        [SerializeField] private SpawnPoint _spawnPointPrefab;

        private Vector2Int _spawnZoneSize;
        private int _step = 2;
        private int _minValue = 1;
        private float _offset = 0.5f;

        public List<SpawnPoint> SpawnPoints { get; private set; } = new List<SpawnPoint>();

        private void OnValidate()
        {
            if (_step < 1)
                _step = _minValue;
        }

        public void Init(int sizeValue)
        {
            _spawnZoneSize = new Vector2Int(sizeValue, sizeValue);

            CreateZone(_spawnZoneSize, _step, _offset);
        }

        public void CreateZone(Vector2Int size, int step, float targetoffset)
        {
            Vector2 offset = new Vector2((size.x - step) * targetoffset, (size.y - step) * targetoffset);

            for (int y = 0; y < size.y; y += step)
            {
                for (int x = 0; x < size.x; x += step)
                {
                    SpawnPoint spawnPoint = Instantiate(_spawnPointPrefab);
                    spawnPoint.transform.SetParent(transform, false);
                    spawnPoint.transform.localPosition = new Vector3(x - offset.x, 0, y - offset.y);
                    SpawnPoints.Add(spawnPoint);
                }
            }
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