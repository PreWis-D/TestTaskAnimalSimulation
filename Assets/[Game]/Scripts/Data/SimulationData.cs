using UnityEngine;

public class SimulationData
{
    private const string _saveFieldSize = "SaveNewGameFieldSize";
    private const string _saveMaxCount = "SaveNewGameMaxCount";
    private const string _saveSpawnForSecond = "SaveNewGameSpawnForSecond";
    private const string _saveTimeSpeed = "SaveNewGameTimeSpeed";

    public int FieldSize { get; private set; } = 2;
    public int MaxCount { get; private set; } = 1;
    public int SpawnForSecond { get; private set; } = 1;
    public int TimeSpeed { get; private set; } = 1;

    public void Load()
    {
        FieldSize = PlayerPrefs.GetInt(_saveFieldSize, FieldSize);
        MaxCount = PlayerPrefs.GetInt(_saveMaxCount, MaxCount);
        SpawnForSecond = PlayerPrefs.GetInt(_saveSpawnForSecond, SpawnForSecond);
        TimeSpeed = PlayerPrefs.GetInt(_saveTimeSpeed, TimeSpeed);
    }

    public void SetFieldSize(int value)
    {
        FieldSize = value;
        PlayerPrefs.SetInt(_saveFieldSize, FieldSize);
    }

    public void SetMaxCount(int value)
    {
        MaxCount = value;
        PlayerPrefs.SetInt(_saveMaxCount, MaxCount);
    }

    public void SetSpawnForSecond(int value)
    {
        SpawnForSecond = value;
        PlayerPrefs.SetInt(_saveSpawnForSecond, SpawnForSecond);
    }

    public void SetTimeSpeed(int value)
    {
        TimeSpeed = value;
        PlayerPrefs.SetInt(_saveTimeSpeed, TimeSpeed);
    }
}