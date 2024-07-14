using Reflex.Attributes;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private SimulationData _simulationData;

    [Inject]
    private void Construct(SimulationData simulationData)
    {
        _simulationData = simulationData;
    }

    private void Start()
    {
        _simulationData.Load();
    }
}
