using SpawnerExample;
using UnityEngine;

public class SpawnersContainer : MonoBehaviour
{
    [SerializeField] private AnimalsContainer _animalsContainer;
    [SerializeField] private FoodsContainer _foodsContainer;
    [SerializeField] private SpawnZone _spawnZone;

    private AnimalSpawner _animalSpawner;
    private FoodSpawner _foodSpawner;

    public void Init(Animal animalPrefab, Food foodPrefab, SimulationData simulationData)
    {
        _spawnZone.Init(simulationData.FieldSize);

        _animalSpawner = new AnimalSpawner(_spawnZone, _animalsContainer, animalPrefab, simulationData);
        _foodSpawner = new FoodSpawner(_spawnZone, _animalSpawner, foodPrefab, _foodsContainer);

        _animalsContainer.AnimalFoodEated += OnAnimalFoodEated;
    }

    public void Activate()
    {
        _animalSpawner.Activate();
    }

    private void OnAnimalFoodEated(Animal animal)
    {
        _foodSpawner.Spawn(animal);
    }

    private void OnDestroy()
    {
        _animalsContainer.AnimalFoodEated -= OnAnimalFoodEated;
    }
}