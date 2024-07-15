using Cysharp.Threading.Tasks;
using UnityEngine;

public class AnimalStateMachine : IAnimalComponent
{
    private Animal _animal;
    private AnimalBehaviourState _currentState;
    private float _eatDistance = 0.3f;

    public bool IsActive { get; private set; }

    #region Core
    public void Init(Animal animal)
    {
        _animal = animal;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
    #endregion

    #region Update
    public void Update()
    {
        if (IsActive == false) return;

        switch (_animal.State)
        {
            case AnimalBehaviourState.Idle:
                Idle();
                break;
            case AnimalBehaviourState.Move:
                Move();
                break;
            case AnimalBehaviourState.Eat:
                Eat();
                break;
        }
    }
    #endregion

    #region Idle
    public async void Idle()
    {
        if (_currentState == _animal.State)
        {
            await SearchFood();
        }
        else
        {
            _currentState = _animal.State;
            _animal.ChangeState(_currentState);
        }
    }

    private async UniTask SearchFood()
    {
        await UniTask.Delay(100);

        if (_animal.TargetFood == null)
        {
            Idle();
        }
        else
        {
            _currentState = AnimalBehaviourState.Move;
            _animal.ChangeState(_currentState);
        }
    }
    #endregion

    #region Move
    private void Move()
    {
        if (_currentState == _animal.State)
        {
            CheckDistance();
        }
        else
        {
            _currentState = AnimalBehaviourState.Move;
            _animal.ChangeState(_currentState);
        }
    }

    private void CheckDistance()
    {
        if (Vector3.Distance(_animal.transform.position, _animal.TargetFood.transform.position) <= _eatDistance)
        {
            _currentState = AnimalBehaviourState.Eat;
            _animal.ChangeState(_currentState);
        }
    }
    #endregion

    #region Eat
    private async void Eat()
    {
        await SearchFood();
    }
    #endregion
}