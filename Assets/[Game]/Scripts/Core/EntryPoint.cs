using Reflex.Attributes;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private SimulationData _simulationData;
    private ProgressSaver _progressSaver;
    private SpawnersContainer _spawnersContainer;
    private Animal _animalPrefab;
    private Food _foodPrefab;
    private GameplayPanel _gameplayPanel;

    [Inject]
    private void Construct(SimulationData simulationData, SpawnersContainer spawnersContainer
        , Animal animalPrefab, Food foodPrefab, GameplayPanel gameplayPanel
        , ProgressSaver progressSaver)
    {
        _simulationData = simulationData;
        _progressSaver = progressSaver;
        _spawnersContainer = spawnersContainer;
        _animalPrefab = animalPrefab;
        _foodPrefab = foodPrefab;
        _gameplayPanel = gameplayPanel;
    }

    private void Start()
    {
        _simulationData.Load();
        _progressSaver.Load();

        _spawnersContainer.Init(_animalPrefab, _foodPrefab, _simulationData, _progressSaver);
        _gameplayPanel.Init(_simulationData, _spawnersContainer, _progressSaver);

        _spawnersContainer.Activate();
    }
}
