using Reflex.Attributes;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    private Menu _menu;
    private SimulationData _simulationData;
    private ProgressSaver _progressSaver;

    [Inject]
    private void Construct(Menu menu, SimulationData simulationData, ProgressSaver progressSaver)
    {
        _menu = menu;
        _simulationData = simulationData;
        _progressSaver = progressSaver;
    }

    private void Start()
    {
        _menu.Init(_simulationData, _progressSaver);
    }
}