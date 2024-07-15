using UnityEngine;

public class SpawnersContainer : MonoBehaviour
{
    [SerializeField] private ParticleController _eatEffect;
    [SerializeField] private AnimalsContainer _animalsContainer;
    [SerializeField] private FoodsContainer _foodsContainer;
    [SerializeField] private VFXsContainer _vFXsContainer;
    [SerializeField] private SpawnZone _spawnZone;

    private AnimalSpawner _animalSpawner;
    private FoodSpawner _foodSpawner;
    private VFXsSpawner _vFXsSpawner;
    private SimulationData _simulationData;
    private ProgressSaver _progressSaver;

    public void Init(Animal animalPrefab, Food foodPrefab, SimulationData simulationData, ProgressSaver progressSaver)
    {
        _simulationData = simulationData;
        _progressSaver = progressSaver;

        _spawnZone.Init(_progressSaver.IsLoadState ? _progressSaver.Size : _simulationData.FieldSize);

        _animalSpawner = new AnimalSpawner(_spawnZone, _animalsContainer, animalPrefab
            , _progressSaver.IsLoadState ? _progressSaver.MaxCount : _simulationData.MaxCount
            , _progressSaver.IsLoadState ? _progressSaver.SpawnForSecond : _simulationData.SpawnForSecond);

        _foodSpawner = new FoodSpawner(_spawnZone, _animalSpawner, foodPrefab, _foodsContainer);
        _vFXsSpawner = new VFXsSpawner(_vFXsContainer);

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
        _progressSaver.SaveSize(_simulationData);
        _progressSaver.SaveMaxCount(_simulationData);
        _progressSaver.SaveSpawnForSecond(_simulationData);

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

    private async void OnAnimalFoodEated(Animal animal)
    {
        _vFXsSpawner.Spawn(_eatEffect, animal.transform.position);
        await _foodSpawner.Spawn(animal);
    }

    private void OnDestroy()
    {
        _animalsContainer.AnimalFoodEated -= OnAnimalFoodEated;
    }
}