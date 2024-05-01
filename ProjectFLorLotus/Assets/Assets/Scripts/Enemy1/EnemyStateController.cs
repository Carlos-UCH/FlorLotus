public class EnemyStateController
{
    public EnemyState currentState;

    public void Initialize(EnemyState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void SwitchState(EnemyState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}