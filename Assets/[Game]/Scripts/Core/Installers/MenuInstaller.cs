using Reflex.Core;
using System;
using UnityEngine;

public class MenuInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private Menu _menuPrefab;

    private ContainerBuilder _containerBuilder;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        _containerBuilder = containerBuilder;
        
        BindMenu();
        BindSimulationData();
        BindProgressSaver();
    }

    private void BindMenu()
    {
        var menu = Instantiate(
            _menuPrefab
            , Vector3.zero
            , Quaternion.identity
            , null);

        _containerBuilder
            .AddSingleton(menu);
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
}
