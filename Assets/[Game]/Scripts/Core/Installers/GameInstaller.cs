using Reflex.Core;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    private ContainerBuilder _containerBuilder;

    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        _containerBuilder = containerBuilder;

        BindSimulationData();
    }

    private void BindSimulationData()
    {
        _containerBuilder
            .AddSingleton(typeof(SimulationData));
    }
}
