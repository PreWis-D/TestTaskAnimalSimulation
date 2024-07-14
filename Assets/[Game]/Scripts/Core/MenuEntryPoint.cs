using Reflex.Attributes;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    private Menu _menu;
    private SimulationData _simulationData;

    [Inject]
    private void Construct(Menu menu, SimulationData simulationData)
    {
        _menu = menu;
        _simulationData = simulationData;
    }

    private void Start()
    {
        _menu.Init(_simulationData);
    }
}