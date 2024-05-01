using UnityEngine;

public class PatrolState : EnemyState
{
    readonly Vector3 startingPos;

    private Vector3 wayPoint;

    public PatrolState(Enemy enemyObject, EnemyStateController stateController) : base(enemyObject, stateController)
    {
        this.enemyObject = enemyObject;
        this.stateController = stateController;
    }

    public override void Enter()
    {
        enemyObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public override void Exit()
    {
    }

    public override void PhysicsUpdate()
    {
        if (Vector3.Distance(enemyObject.transform.position, wayPoint) == 0 || Time.fixedTime % 2 == 0)
        {
            SetNewDestination();
        }
        enemyObject.transform.position = Vector3.MoveTowards(enemyObject.transform.position, wayPoint, 1f * Time.deltaTime);
    }

    public override void FrameUpdate()
    {
    }

    void SetNewDestination()
    {
        wayPoint = this.enemyObject.transform.position + new Vector3(Random.Range(-2.6f, 2.6f), Random.Range(-2.6f, 2.6f));
    }
}
