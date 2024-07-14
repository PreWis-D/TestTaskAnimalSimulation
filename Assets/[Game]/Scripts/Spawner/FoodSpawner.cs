using SpawnerExample;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner
{
    private SpawnZone _spawnZone;
    private AnimalSpawner _animalSpawner;
    private Food _foodPrefab;
    private FoodsContainer _foodsContainer;

    private List<Food> _foodPool = new List<Food>();

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
        if (_foodPool.Count < 1)
        {
            Create(animal);
        }
        else
        {
            foreach (var food in _foodPool)
            {
                if (food.gameObject.activeSelf == false)
                {
                    food.gameObject.SetActive(true);
                    food.transform.position = SearchSpawnPoint().transform.position;
                    animal.SetFood(food);
                    return;
                }
            }

            Create(animal);
        }
    }

    private void Create(Animal animal)
    {
        var food = Object.Instantiate(_foodPrefab, SearchSpawnPoint().transform.position, Quaternion.identity, _foodsContainer.transform);
        _foodPool.Add(food);
        animal.SetFood(food);
    }

    private SpawnPoint SearchSpawnPoint()
    {
        return null;
    }

    private void OnDestroy()
    {
        _animalSpawner.AnimalSpawned -= OnAnimalSpawned;
    }
}
