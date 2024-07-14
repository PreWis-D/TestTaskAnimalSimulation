using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SpawnerExample
{
    public abstract class Spawner : MonoBehaviour
    {
        public abstract void Spawn<T>(T prefab, Transform parent) where T : MonoBehaviour;
    }
}