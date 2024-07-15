using System;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private AnimalMover _mover;
    [SerializeField] private ColorChanger _colorChanger;

    private AnimalStateMachine _stateMachine;
    private List<IAnimalComponent> _components = new List<IAnimalComponent>();

    public ColorChanger ColorChanger => _colorChanger;

    public Food TargetFood { get; private set; }
    public AnimalBehaviourState State { get; private set; }

    public event Action<Animal> FoodEated;

    #region Core
    public void Init()
    {
        _stateMachine = new AnimalStateMachine();

        _mover.Init(this);
        _stateMachine.Init(this);

        _colorChanger.GenerateRandomColor();
        Debug.LogWarning(_colorChanger.Color);

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
        foreach (var component in _components)
            component.Deactivate();
    }
    #endregion

    private void Update()
    {
        _stateMachine?.Update();
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
                transform.LookAt(TargetFood.transform.position);
                _mover.Move(TargetFood.transform.position);
                break;
            case AnimalBehaviourState.Eat:
                EatFood();
                break;
        }
    }

    private void EatFood()
    {
        _mover.StopMove();
        TargetFood.gameObject.SetActive(false);
        SetFood(null);
        FoodEated?.Invoke(this);
    }
}