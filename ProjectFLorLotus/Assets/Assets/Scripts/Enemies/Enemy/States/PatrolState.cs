using StateMachine;
using UnityEngine;
namespace Enemy
{
    public class PatrolState : State<Enemy>
    {
        private Vector3 wayPoint;

        public PatrolState(Enemy enemyObject, StateController<Enemy> stateController) : base(enemyObject, stateController)
        {
            this.gameObject = enemyObject;
            this.stateController = stateController;
        }

        public override void Enter()
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }

        public override void Exit()
        {
        }

        public override void PhysicsUpdate()
        {
            if (Vector3.Distance(this.gameObject.transform.position, wayPoint) == 0 || Time.fixedTime % 2 == 0)
            {
                SetNewDestination();
            }
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, wayPoint, 1f * Time.deltaTime);
        }

        public override void FrameUpdate()
        {
        gameObject.facingDirection = wayPoint - gameObject.transform.position;
        }

        void SetNewDestination()
        {
            wayPoint = this.gameObject.transform.position + new Vector3(Random.Range(-2.6f, 2.6f), Random.Range(-2.6f, 2.6f));
        }
    }
}