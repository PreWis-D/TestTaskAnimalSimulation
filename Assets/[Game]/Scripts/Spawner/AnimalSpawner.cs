using Cysharp.Threading.Tasks;
using SpawnerExample;
using System;
using System.Threading;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class AnimalSpawner
{
    private Animal _animalPrefab;
    private SpawnZone _spawnZone;
    private AnimalsContainer _animalsContainer;
    private CancellationTokenSource _cancellationTokenSource;

    private int _maxCount;
    private int _spawnCount;
    private float _cooldown = 1f;

    public event Action<Animal> AnimalSpawned;

    public AnimalSpawner(SpawnZone spawnZone, AnimalsContainer animalsContainer, Animal animalPrefab, SimulationData simulationData)
    {
        _spawnZone = spawnZone;
        _animalsContainer = animalsContainer;
        _animalPrefab = animalPrefab;

        _maxCount = simulationData.MaxCount;
        _spawnCount = simulationData.Movespeed;

        _cancellationTokenSource = new CancellationTokenSource();
    }

    public void Activate()
    {
        Spawn().Forget();
    }

    public void Deactivate()
    {
        _cancellationTokenSource.Cancel();
    }

    private async UniTask Spawn()
    {
        while (_animalsContainer.Animals.Count < _maxCount)
        {
            await UniTask.Delay((int)_cooldown * 1000);

            for (int i = 0; i < _spawnCount; i++)
            {
                int randomNumber = Random.Range(0, _spawnZone.SpawnPoints.Count - 1);

                if (_spawnZone.SpawnPoints[randomNumber].IsEmpty)
                {
                    Animal animal = Object.Instantiate(_animalPrefab, _spawnZone.SpawnPoints[randomNumber].transform.position, Quaternion.identity, _animalsContainer.transform);
                    animal.Init();
                    _animalsContainer.Add(animal);
                    AnimalSpawned?.Invoke(animal);
                }
            }
        }
    }
}