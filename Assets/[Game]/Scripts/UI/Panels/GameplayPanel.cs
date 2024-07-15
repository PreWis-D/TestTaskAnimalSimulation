using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayPanel : BasePanel
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private SettingSlider _timeSlider;

    public void Init(SimulationData simulationData)
    {
        _timeSlider.Init();
        _timeSlider.SetSliderValue(simulationData.TimeSpeed);

        OnSliderChanged(_timeSlider);

        _saveButton.onClick.AddListener(OnSaveButtonClick);
        _timeSlider.SliderChanged += OnSliderChanged;
    }

    private void OnSaveButtonClick()
    {
        throw new NotImplementedException();
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