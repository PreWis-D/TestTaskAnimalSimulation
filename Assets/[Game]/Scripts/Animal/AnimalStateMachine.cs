using Cysharp.Threading.Tasks;

public class AnimalStateMachine : IAnimalComponent
{
    private Animal _animal;
    private AnimalBehaviourState _currentState;

    public bool IsActive {  get; private set; }

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
        }
    }

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

        if (_animal.TargetFood == null) return;

        _currentState = AnimalBehaviourState.Move;
        _animal.ChangeState(_currentState);
    }
    #endregion

    #region Move
    private void Move()
    {

    }
    #endregion
}