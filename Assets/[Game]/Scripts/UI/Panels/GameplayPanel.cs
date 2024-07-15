using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : BasePanel
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private SettingSlider _timeSlider;

    private SpawnersContainer _spawnersContainer;
    private ProgressSaver _progressSaver;

    public void Init(SimulationData simulationData, SpawnersContainer spawnersContainer, ProgressSaver progressSaver)
    {
        _spawnersContainer = spawnersContainer;
        _progressSaver = progressSaver;

        _timeSlider.Init();

        if (_progressSaver.IsLoadState == false)
            _timeSlider.SetSliderValue(simulationData.TimeSpeed);
        else
            _timeSlider.SetSliderValue(_progressSaver.GameSpeed);

        OnSliderChanged(_timeSlider);

        _saveButton.onClick.AddListener(OnSaveButtonClick);
        _timeSlider.SliderChanged += OnSliderChanged;
    }

    private void OnSaveButtonClick()
    {
        _progressSaver.SaveGameSpeed(_timeSlider.Slider.value);
        _spawnersContainer.Save();
    }

    private void OnSliderChanged(SettingSlider slider)
    {
        Time.timeScale = slider.Slider.value;
    }

    private void OnDestroy()
    {
        _saveButton.onClick.RemoveListener(OnSaveButtonClick);
        _timeSlider.SliderChanged -= OnSliderChanged;
    }
}