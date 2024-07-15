using UnityEngine;

    [RequireComponent(typeof(SphereCollider))]
    public class SpawnPoint : MonoBehaviour
    {
        private SphereCollider _collider;
        private Food _food;
        private Animal _animal;

        public bool IsFoodEmpty { get; private set; } = true;
        public bool IsAnimalEmpty { get; private set; } = true;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Animal animal))
            {
                _animal = animal;
                IsAnimalEmpty = false;
            }
            else if (other.TryGetComponent(out Food food))
            {
                _food = food;
                IsFoodEmpty = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Animal animal))
            {
                _animal = null;
                IsAnimalEmpty = true;
            }
            else if (other.TryGetComponent(out Food food))
            {
                _food = null;
                IsFoodEmpty = true;
            }
        }
    }