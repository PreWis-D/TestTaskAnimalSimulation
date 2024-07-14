using Reflex.Attributes;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private SimulationData _simulationData;
    private SpawnersContainer _spawnersContainer;
    private Animal _animalPrefab;
    private Food _foodPrefab;

    [Inject]
    private void Construct(SimulationData simulationData, SpawnersContainer spawnersContainer
        , Animal animalPrefab, Food foodPrefab)
    {
        _simulationData = simulationData;
        _spawnersContainer = spawnersContainer;
        _animalPrefab = animalPrefab;
        _foodPrefab = foodPrefab;
    }

    private void Start()
    {
        _simulationData.Load();

        _spawnersContainer.Init(_animalPrefab, _foodPrefab, _simulationData);

        _spawnersContainer.Activate();
    }
}
