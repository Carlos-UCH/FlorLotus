using StateMachine;
using UnityEngine;
using Drone;
namespace Enemy
{
    public class AttackState : State<Enemy>
    {
        float attackTimeout = 1f;
        float timeSinceLastAttack = 1f;
        CommonPlayer player;
        public AttackState(Enemy enemyObject, StateController<Enemy> stateController, CommonPlayer player) : base(enemyObject, stateController)
        {
            this.gameObject = enemyObject;
            this.stateController = stateController;
            this.player = player;
        }

        public override void Enter()
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        public override void Exit()
        {
        }

        public override void FrameUpdate()
        {
        }

        public override void PhysicsUpdate()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack > attackTimeout)
            {
                player.health -= 10;
                timeSinceLastAttack = 0f;
            }
        }
    }

}

