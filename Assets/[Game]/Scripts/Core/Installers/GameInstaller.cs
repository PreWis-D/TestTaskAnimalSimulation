using Reflex.Core;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private SpawnersContainer _spawnersContainer;
    [SerializeField] private Animal _animalPrefab;
    [SerializeField] private Food _foodPrefab;

    private ContainerBuilder _containerBuilder;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        _containerBuilder = containerBuilder;

        BindSimulationData();
        BindSpawnersContainer();
    }

    private void BindSimulationData()
    {
        _containerBuilder
            .AddSingleton(typeof(SimulationData));
    }

    private void BindSpawnersContainer()
    {
        var spawnersContainer = Instantiate(
            _spawnersContainer
            , Vector3.zero
            , Quaternion.identity
            , null);

        _containerBuilder
            .AddSingleton(spawnersContainer);
    }

    private void BindAnimalPrefab()
    {
        _containerBuilder
            .AddSingleton(_animalPrefab);
    }

    private void BindFoodPrefab()
    {
        _containerBuilder
            .AddSingleton(_foodPrefab);
    }
}
