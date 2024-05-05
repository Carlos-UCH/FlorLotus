using StateMachine;
using UnityEngine;

namespace Enemy
{
    public class ChaseState : State<Enemy>
    {
        readonly player_controller player;
        public ChaseState(Enemy enemyObject, StateController<Enemy> stateController, player_controller player) : base(enemyObject, stateController)
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
        }
    }
}