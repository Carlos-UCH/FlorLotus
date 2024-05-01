using UnityEngine;

public class ChaseState : EnemyState
{
    player_controller player;
    public ChaseState(Enemy enemyObject, EnemyStateController stateController, player_controller player) : base(enemyObject, stateController)
    {
        this.enemyObject = enemyObject;
        this.stateController = stateController;
        this.player = player;
    }

    public override void Enter()
    {
        enemyObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void Exit()
    {
    }

    public override void FrameUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
        enemyObject.transform.position = Vector3.MoveTowards(enemyObject.transform.position, player.transform.position, 4f * Time.deltaTime);
    }
}
