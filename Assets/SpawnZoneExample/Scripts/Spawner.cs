using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SpawnerExample
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Character _prefab;
        [SerializeField] private int _maxCount;
        [SerializeField] private ObjectsConteiner _objectsConteiner;
        [SerializeField] private float _cooldown;

        private SpawnZone _spawnZone;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _spawnInJob;

        public event UnityAction Spawned;

        private void Awake()
        {
            _spawnZone = GetComponentInParent<SpawnZone>();
            _waitForSeconds = new WaitForSeconds(_cooldown);
        }

        private void Start()
        {
            _spawnInJob = StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            if (_maxCount <= 0 && _spawnInJob != null)
                StopCoroutine(_spawnInJob);

            if (_objectsConteiner.ObjectsCount >= _maxCount && _spawnInJob != null)
                StopCoroutine(_spawnInJob);


            while (_objectsConteiner.ObjectsCount < _maxCount)
            {
                yield return _waitForSeconds;

                int randomNumber = Random.Range(0, _spawnZone.SpawnPoints.Count - 1);

                if (_spawnZone.SpawnPoints[randomNumber].IsEmpty)
                {
                    Character character = Instantiate(_prefab, _spawnZone.SpawnPoints[randomNumber].transform.position, Quaternion.identity, _objectsConteiner.transform);
                    Spawned?.Invoke();
                }
            }
        }
    }
}