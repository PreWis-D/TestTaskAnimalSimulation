using UnityEngine;

public class SpawnersContainer : MonoBehaviour
{
    [SerializeField] private AnimalsContainer _animalsContainer;
    [SerializeField] private FoodsContainer _foodsContainer;
    [SerializeField] private SpawnZone _spawnZone;

    private AnimalSpawner _animalSpawner;
    private FoodSpawner _foodSpawner;
    private ProgressSaver _progressSaver;

    public void Init(Animal animalPrefab, Food foodPrefab, SimulationData simulationData, ProgressSaver progressSaver)
    {
        _progressSaver = progressSaver;

        _spawnZone.Init(simulationData.FieldSize);

        _animalSpawner = new AnimalSpawner(_spawnZone, _animalsContainer, animalPrefab, simulationData);
        _foodSpawner = new FoodSpawner(_spawnZone, _animalSpawner, foodPrefab, _foodsContainer);

        _animalsContainer.AnimalFoodEated += OnAnimalFoodEated;

        Load();
    }

    public void Activate()
    {
        _animalSpawner.Activate();
    }

    public void Deactivate()
    {
        _animalSpawner.Deactivate();
    }

    public void Save()
    {
        _progressSaver.SaveAnimals(_animalsContainer.Animals);
        _progressSaver.SaveAnimalPositions(_animalsContainer.Animals);
        _progressSaver.SaveAnimalRotations(_animalsContainer.Animals);
        _progressSaver.SaveAnimalColors(_animalsContainer.Animals);

        _progressSaver.SaveFoods(_foodsContainer.Foods);
        _progressSaver.SaveFoodPositions(_foodsContainer.Foods);
    }

    public void Load()
    {
        if (_progressSaver.Animals.Count < 1 || _progressSaver.IsLoadState == false)
            return;

        _animalSpawner.Load(_progressSaver);
        _foodSpawner.Load(_progressSaver);
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