using System.Collections.Generic;
using UnityEngine;

public class ProgressSaver
{
    private const string _saveLoadState = "SaveLoadState";
    private const string _saveGameSpeed = "SaveGameSpeed";

    private const string _saveFieldSize = "SaveLoadGameFieldSize";
    private const string _saveMaxCount = "SaveLoadGameMaxCount";
    private const string _saveSpawnForSecond = "SaveLoadGameSpawnForSecond";

    private const string _saveAnimals = "SaveAnimals";
    private const string _saveAnimalPositions = "SaveAnimalPositions";
    private const string _saveAnimalRotations = "SaveAnimalRotations";
    private const string _saveAnimalColors = "SaveAnimalColors";

    private const string _saveFoods = "SaveFoods";
    private const string _saveFoodPositions = "SaveFoodPositions";

    public bool IsLoadState { get; private set; }
    public float GameSpeed { get; private set; }
    public int Size { get; private set; } = 1;
    public int MaxCount { get; private set; } = 1;
    public int SpawnForSecond { get; private set; } = 1;

    public List<Animal> Animals { get; private set; } = new List<Animal>();
    public List<Vector3> AnimalPositions { get; private set; } = new List<Vector3>();
    public List<Quaternion> AnimalRotations { get; private set; } = new List<Quaternion>();
    public List<Color> AnimalColors { get; private set; } = new List<Color>();

    public List<Food> Foods { get; private set; } = new List<Food>();
    public List<Vector3> FoodPositions { get; private set; } = new List<Vector3>();

    public void Load()
    {
        IsLoadState = PlayerPrefsExtra.GetBool(_saveLoadState);
        GameSpeed = PlayerPrefs.GetFloat(_saveGameSpeed);

        Size = PlayerPrefs.GetInt(_saveFieldSize, Size);
        MaxCount = PlayerPrefs.GetInt(_saveMaxCount, MaxCount);
        SpawnForSecond = PlayerPrefs.GetInt(_saveSpawnForSecond, SpawnForSecond);

        Animals = PlayerPrefsExtra.GetList<Animal>(_saveAnimals);
        AnimalPositions = PlayerPrefsExtra.GetList<Vector3>(_saveAnimalPositions);
        AnimalRotations = PlayerPrefsExtra.GetList<Quaternion>(_saveAnimalRotations);
        AnimalColors = PlayerPrefsExtra.GetList<Color>(_saveAnimalColors);

        Foods = PlayerPrefsExtra.GetList<Food>(_saveFoods);
        FoodPositions = PlayerPrefsExtra.GetList<Vector3>(_saveFoodPositions);
    }

    public void SaveLoadState(bool isLoad)
    {
        IsLoadState = isLoad;
        PlayerPrefsExtra.SetBool(_saveLoadState, IsLoadState);
    }

    public void SaveGameSpeed(float timeSpeed)
    {
        GameSpeed = timeSpeed;
        PlayerPrefs.SetFloat(_saveGameSpeed, GameSpeed);
    }

    public void SaveSize(SimulationData simulationData)
    {
        Size = simulationData.FieldSize;
        PlayerPrefs.SetInt(_saveFieldSize, Size);
    }

    public void SaveMaxCount(SimulationData simulationData)
    {
        MaxCount = simulationData.MaxCount;
        PlayerPrefs.SetInt(_saveMaxCount, MaxCount);
    }

    public void SaveSpawnForSecond(SimulationData simulationData)
    {
        SpawnForSecond = simulationData.SpawnForSecond;
        PlayerPrefs.SetInt(_saveSpawnForSecond, SpawnForSecond);
    }

    public void SaveAnimals(List<Animal> animals)
    {
        Animals = animals;
        PlayerPrefsExtra.SetList(_saveAnimals, Animals);
    }

    public void SaveAnimalPositions(List<Animal> animals)
    {
        List<Vector3> positions = new List<Vector3>();

        foreach (var animal in animals)
            positions.Add(animal.transform.position);

        AnimalPositions = positions;
        PlayerPrefsExtra.SetList(_saveAnimalPositions, AnimalPositions);
    }

    public void SaveAnimalRotations(List<Animal> animals)
    {
        List<Quaternion> rotations = new List<Quaternion>();

        foreach (var animal in animals)
            rotations.Add(animal.transform.rotation);

        AnimalRotations = rotations;
        PlayerPrefsExtra.SetList(_saveAnimalRotations, AnimalRotations);
    }

    public void SaveAnimalColors(List<Animal> animals)
    {
        List<Color> colors = new List<Color>();

        foreach (var animal in animals)
            colors.Add(animal.ColorChanger.Color);

        AnimalColors = colors;
        PlayerPrefsExtra.SetList(_saveAnimalColors, AnimalColors);
    }

    public void SaveFoods(List<Food> foods)
    {
        Foods = foods;
        PlayerPrefsExtra.SetList(_saveFoods, Foods);
    }

    public void SaveFoodPositions(List<Food> foods)
    {
        List<Vector3> positions = new List<Vector3>();

        foreach (var food in foods)
            positions.Add(food.transform.position);

        FoodPositions = positions;
        PlayerPrefsExtra.SetList(_saveFoodPositions, FoodPositions);
    }
}