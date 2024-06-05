using StateMachine;
using UnityEngine;
using Drone;

namespace Enemy
{
    public class ChaseState : State<Enemy>
    {
        readonly CommonPlayer player;
        public ChaseState(Enemy enemyObject, StateController<Enemy> stateController, CommonPlayer player) : base(enemyObject, stateController)
        {
            this.gameObject = enemyObject;
            this.stateController = stateController;
            this.player = player;
        }

        public override void Enter()
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }

        public override void Exit()
        {
        }

        public override void FrameUpdate()
        {
        }

        public override void PhysicsUpdate()
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 4f * Time.deltaTime);
            // look at player
            this.gameObject.facingDirection = player.transform.position - this.gameObject.transform.position;
        }
    }
}