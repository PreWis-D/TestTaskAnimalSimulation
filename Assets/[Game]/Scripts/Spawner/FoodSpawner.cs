using SpawnerExample;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner
{
    private SpawnZone _spawnZone;
    private AnimalSpawner _animalSpawner;
    private Food _foodPrefab;
    private FoodsContainer _foodsContainer;

    public FoodSpawner(SpawnZone spawnZone, AnimalSpawner animalSpawner, Food foodPrefab, FoodsContainer foodsContainer)
    {
        _spawnZone = spawnZone;
        _animalSpawner = animalSpawner;
        _foodPrefab = foodPrefab;
        _foodsContainer = foodsContainer;

        _animalSpawner.AnimalSpawned += OnAnimalSpawned;
    }

    private void OnAnimalSpawned(Animal animal)
    {
        Spawn(animal);
    }

    public void Spawn(Animal animal)
    {
        if (_foodsContainer.Foods.Count < 1)
        {
            Create(animal);
        }
        else
        {
            var food = _foodsContainer.GetFood();

            if (food != null)
            {
                food.gameObject.SetActive(true);
                food.transform.position = SearchSpawnPoint(animal).transform.position;
                food.SetColor(animal.ColorChanger.Color);
                animal.SetFood(food);
                return;
            }

            Create(animal);
        }
    }

    private void Create(Animal animal)
    {
        var food = Object.Instantiate(_foodPrefab, SearchSpawnPoint(animal).transform.position, Quaternion.identity, _foodsContainer.transform);
        food.SetColor(animal.ColorChanger.Color);
        animal.SetFood(food);
        _foodsContainer.Add(food);
    }

    private SpawnPoint SearchSpawnPoint(Animal animal)
    {
        Collider[] colliders = Physics.OverlapSphere(animal.transform.position, 5);
        List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        for (int i = 0; i < colliders.Length; i++)
        {
            var spawnPoint = colliders[i].GetComponent<SpawnPoint>();

            if (spawnPoint)
                spawnPoints.Add(spawnPoint);
        }

        int randomIndex = Random.Range(0, spawnPoints.Count);

        return spawnPoints[randomIndex];
    }

    private void OnDestroy()
    {
        _animalSpawner.AnimalSpawned -= OnAnimalSpawned;
    }
}
