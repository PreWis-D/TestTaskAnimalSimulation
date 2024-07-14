using UnityEngine;

public class SimulationData
{
    private const string _saveFieldSize = "SaveFieldSize";
    private const string _saveMaxCount = "SaveMaxCount";
    private const string _saveMoveSpeed = "SaveMoveSpeed";
    private const string _saveTimeSpeed = "SaveTimeSpeed";

    public int FieldSize { get; private set; } = 2;
    public int MaxCount { get; private set; } = 1;
    public int Movespeed { get; private set; } = 1;
    public int TimeSpeed { get; private set; } = 1;

    public void Load()
    {
        FieldSize = PlayerPrefs.GetInt(_saveFieldSize, FieldSize);
        MaxCount = PlayerPrefs.GetInt(_saveMaxCount, MaxCount);
        Movespeed = PlayerPrefs.GetInt(_saveMoveSpeed, Movespeed);
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

    public void SetMoveSpeed(int value)
    {
        Movespeed = value;
        PlayerPrefs.SetInt(_saveMaxCount, MaxCount);
    }

    public void SetTimeSpeed(int value)
    {
        TimeSpeed = value;
        PlayerPrefs.SetInt(_saveTimeSpeed, TimeSpeed);
    }
}