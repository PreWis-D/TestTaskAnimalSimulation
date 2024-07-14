using System;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private AnimalMover _mover;

    private AnimalStateMachine _stateMachine;
    private List<IAnimalComponent> _components = new List<IAnimalComponent>();

    public Food TargetFood {  get; private set; }
    public AnimalBehaviourState State { get; private set; }

    public event Action<Animal> FoodEated; 

    public void Init()
    {
        _stateMachine = new AnimalStateMachine();

        _components.Add(_mover);
        _components.Add(_stateMachine);
    }

    public void Activate()
    {
        foreach (var component in _components)
            component.Activate();
    }

    public void Deactivate()
    {
        foreach(var component in _components)
            component.Deactivate();
    }

    public void SetFood(Food food)
    {
        TargetFood = food;
    }

    public void ChangeState(AnimalBehaviourState state)
    {
        State = state;

        switch (State)
        {
            case AnimalBehaviourState.Idle:
                _mover.StopMove();
                break;
            case AnimalBehaviourState.Move:
                _mover.Move(TargetFood.transform.position);
                break;
        }
    }
}