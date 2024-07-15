using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuMainPanel : BasePanel
{
    [SerializeField] private Button _newGameButton;   
    [SerializeField] private Button _loadGameButton;

    public event Action NewGameButtonClicked;
    public event Action LoadGameButtonClicked;

    public void Init(ProgressSaver progressSaver)
    {
        _newGameButton.onClick.AddListener(OnNewGameButtonClicked);
        _loadGameButton.onClick.AddListener(OnLoadGameButtonClicked);

        progressSaver.Load();

        if (progressSaver.Animals.Count < 1)
            _loadGameButton.interactable = false;
    }

    private void OnNewGameButtonClicked()
    {
        NewGameButtonClicked?.Invoke();
    }

    private void OnLoadGameButtonClicked()
    {
        LoadGameButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _newGameButton.onClick.RemoveListener(OnNewGameButtonClicked);
        _loadGameButton.onClick.RemoveListener(OnLoadGameButtonClicked);
    }
}