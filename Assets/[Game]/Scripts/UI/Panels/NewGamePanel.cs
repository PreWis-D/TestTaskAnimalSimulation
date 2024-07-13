using System;
using UnityEngine;
using UnityEngine.UI;

public class NewGamePanel : BasePanel
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _backButton;

    public event Action StartGameButtonClicked;
    public event Action BackButtonClicked;

    public void Init()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        _backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnStartGameButtonClicked()
    {
        StartGameButtonClicked?.Invoke();
    }

    private void OnBackButtonClicked()
    {
        BackButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _startGameButton.onClick.RemoveListener(OnStartGameButtonClicked);
        _backButton.onClick.RemoveListener(OnBackButtonClicked);
    }
}