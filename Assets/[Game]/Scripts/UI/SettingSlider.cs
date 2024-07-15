using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    [SerializeField] private SettingSliderType _type;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_InputField _inputField;

    public SettingSliderType Type => _type;
    public Slider Slider => _slider;


    public event Action<SettingSlider> SliderChanged;

    public void Init()
    {
        Slider.onValueChanged.AddListener(OnValueChanged);
        _inputField.onValueChanged.AddListener(OnValueChanged);

        SetValueText();
    }

    public void SetSliderValue(float newValue)
    {
        _slider.value = newValue;
        SetValueText();
    }

    public void SetMaxValue(float newValue)
    {
        _slider.maxValue = newValue;
        SetValueText();
    }

    private void OnValueChanged(float arg0)
    {
        SliderChanged?.Invoke(this);
        SetValueText();
    }

    private void OnValueChanged(string arg0)
    {
        int converting;
        bool trueConverting;

        trueConverting = int.TryParse(arg0, out converting);

        if (trueConverting == false)
            SetValueText();
        else
            SetSliderValue(converting);
    }

    private void SetValueText()
    {
        _inputField.text = ((int)_slider.value).ToString();
    }

    private void OnDestroy()
    {
        Slider.onValueChanged.RemoveListener(OnValueChanged);
        _inputField.onValueChanged.RemoveListener(OnValueChanged);
    }
}

public enum SettingSliderType
{
    None,
    Area,
    Count,
    SpawnForSecond,
    TimeScale
}