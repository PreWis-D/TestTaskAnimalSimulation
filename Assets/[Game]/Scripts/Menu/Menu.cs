using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private MenuMainPanel _mainPanel;
    [SerializeField] private NewGamePanel _newGamePanel;

    #region Core
    public void Init()
    {
        _mainPanel.Init();
        _newGamePanel.Init();

        _newGamePanel.Hide();

        Subscrube();
    }

    private void Subscrube()
    {
        _mainPanel.NewGameButtonClicked += OnNewGameButtonClicked;
        _mainPanel.LoadGameButtonClicked += OnLoadGameButtonClicked;
        _newGamePanel.StartGameButtonClicked += OnStartGameButtonClicked;
        _newGamePanel.BackButtonClicked += OnBackButtonClicked;
    }

    private void Unsubscribe()
    {
        _mainPanel.NewGameButtonClicked -= OnNewGameButtonClicked;
        _mainPanel.LoadGameButtonClicked -= OnLoadGameButtonClicked;
        _newGamePanel.StartGameButtonClicked -= OnStartGameButtonClicked;
        _newGamePanel.BackButtonClicked -= OnBackButtonClicked;
    }
    #endregion

    #region ButtonEvents
    private void OnNewGameButtonClicked()
    {
        _mainPanel.Hide();
        _newGamePanel.Show();
    }

    private void OnLoadGameButtonClicked()
    {
        // load game
    }

    private void OnStartGameButtonClicked()
    {
        // start new game
    }

    private void OnBackButtonClicked()
    {
        _newGamePanel.Hide();
        _mainPanel.Show();
    }
    #endregion

    private void OnDestroy()
    {
        Unsubscribe();
    }
}