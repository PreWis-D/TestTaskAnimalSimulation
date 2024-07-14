using UnityEngine;

namespace SpawnerExample
{
    public class ObjectsConteiner : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;

        private int _objectsCount;

        public int ObjectsCount => _objectsCount;

        private void Awake()
        {
            _objectsCount = 0;
        }

        //private void OnEnable()
        //{
        //    _spawner.Spawned += OnSpawned;
        //}

        //private void OnDisable()
        //{
        //    _spawner.Spawned -= OnSpawned;
        //}

        private void OnSpawned()
        {
            Add();
        }

        private void Add()
        {
            _objectsCount++;
        }

        private void Remove()
        {
            _objectsCount--;
        }
    }
}