using System;
using UnityEngine;
using UnityEngine.UI;

public class NewGamePanel : BasePanel
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private SettingSlider[] _settingSliders;

    private SimulationData _simulationData;

    public event Action StartGameButtonClicked;
    public event Action BackButtonClicked;

    #region Core
    public void Init(SimulationData simulationData)
    {
        for (int i = 0; i < _settingSliders.Length; i++)
            _settingSliders[i].Init();

        Subscribe();
    }

    private void Subscribe()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        _backButton.onClick.AddListener(OnBackButtonClicked);

        for (int i = 0; i < _settingSliders.Length; i++)
            _settingSliders[i].SliderChanged += OnSliderChanged;
    }

    private void Unsubscribe()
    {
        _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
        _backButton.onClick.RemoveListener(OnBackButtonClicked);

        for (int i = 0; i < _settingSliders.Length; i++)
            _settingSliders[i].SliderChanged -= OnSliderChanged;
    }
    #endregion

    #region Events
    private void OnSliderChanged(SettingSlider slider)
    {
        switch (slider.Type)
        {
            case SettingSliderType.Area:
                CalculateCountValue(GetSlider(SettingSliderType.Count), slider);
                break;
            case SettingSliderType.Count:
                break;
        }
    }

    private void OnStartGameButtonClicked()
    {
        SetDataValues();

        StartGameButtonClicked?.Invoke();
    }

    private void OnBackButtonClicked()
    {
        BackButtonClicked?.Invoke();
    }
    #endregion

    private SettingSlider GetSlider(SettingSliderType type)
    {
        for (int i = 0; i < _settingSliders.Length; i++)
        {
            if (_settingSliders[i].Type == type)
                return _settingSliders[i];
        }

        return null;
    }

    private void CalculateCountValue(SettingSlider currentSlider, SettingSlider targetSlider)
    {
        if (currentSlider == null || targetSlider == null)
            throw new ArgumentNullException("slider null");

        var targetValue = (int)targetSlider.Slider.value * (int)targetSlider.Slider.value * 0.5f;
        currentSlider.SetMaxValue(targetValue);

        if (currentSlider.Slider.value > currentSlider.Slider.maxValue)
            currentSlider.SetSliderValue(targetValue);
    }

    private void SetDataValues()
    {
        for (int i = 0; i < _settingSliders.Length; i++)
        {
            switch (_settingSliders[i].Type)
            {
                case SettingSliderType.Area:
                    _simulationData.SetFieldSize((int)_settingSliders[i].Slider.value);
                    break;
                case SettingSliderType.Count:
                    _simulationData.SetMaxCount((int)_settingSliders[i].Slider.value);
                    break;
                case SettingSliderType.Speed:
                    _simulationData.SetMoveSpeed((int)_settingSliders[i].Slider.value);
                    break;
            }
        }
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}