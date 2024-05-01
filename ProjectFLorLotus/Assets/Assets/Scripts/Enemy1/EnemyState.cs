
/// The EnemyState class is an abstract class that defines the behavior for different states that an enemy can be in.
public abstract class EnemyState
{
    protected Enemy enemyObject;
    protected EnemyStateController stateController;

    /// <summary>
    /// Initializes a new instance of the EnemyState class. It may receive other parameters to handle more specific behavior.
    /// </summary>
    public EnemyState(Enemy enemyObject, EnemyStateController stateController)
    {
        this.enemyObject = enemyObject;
        this.stateController = stateController;
    }

    /// <summary>
    /// called when the enemy enters this state.
    /// </summary>
    public abstract void Enter();
    /// <summary>
    /// called when the enemy exits this state.
    /// </summary>
    public abstract void Exit();
    /// <summary>
    /// It is called every frame to update the behavior of the enemy in this state.
    /// </summary>
    public abstract void FrameUpdate();
    /// <summary>
    /// It is called every physics frame to handle physics-related behavior of the enemy in this state.
    /// </summary>
    public abstract void PhysicsUpdate();
}