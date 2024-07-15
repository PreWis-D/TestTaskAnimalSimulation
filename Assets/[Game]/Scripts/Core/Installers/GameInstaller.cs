using Reflex.Core;
using System;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private SpawnersContainer _spawnersContainer;
    [SerializeField] private GameplayPanel _gameplayPanelPrefab;
    [SerializeField] private Animal _animalPrefab;
    [SerializeField] private Food _foodPrefab;

    private ContainerBuilder _containerBuilder;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        _containerBuilder = containerBuilder;

        BindSimulationData();
        BindProgressSaver();
        BindSpawnersContainer();
        BindGameplayPanel();
        BindAnimalPrefab();
        BindFoodPrefab();
    }

    private void BindSimulationData()
    {
        _containerBuilder
            .AddSingleton(typeof(SimulationData));
    }

    private void BindProgressSaver()
    {
        _containerBuilder
           .AddSingleton(typeof(ProgressSaver));
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

    private void BindGameplayPanel()
    {
        var gameplayPlanel = Instantiate(
            _gameplayPanelPrefab
            , Vector3.zero
            , Quaternion.identity
            , null);

        _containerBuilder
            .AddSingleton(gameplayPlanel);
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
