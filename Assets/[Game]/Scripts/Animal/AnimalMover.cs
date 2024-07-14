using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class AnimalMover : IAnimalComponent
{
    [SerializeField] private NavMeshAgent _agent;

    private Animal _animal;

    public bool IsActive {  get; private set; }

    public void Init(Animal animal)
    {
        _animal = animal;
    }

    public void Activate()
    {
        IsActive = true;
        if (_agent) _agent.enabled = true;
    }

    public void Deactivate()
    {
        IsActive = false;
        if (_agent) _agent.enabled = false;
    }

    public void StopMove()
    {
        if (_agent.enabled && _agent.isStopped == false)
        {
            _agent.isStopped = true;
        }
    }

    public void Move(Vector3 targetPosition)
    {
        if (_agent.enabled)
        {
            if (_agent.isStopped)
                _agent.isStopped = false;

            _agent.SetDestination(targetPosition);
        }
    }

}