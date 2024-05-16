using StateMachine;
using UnityEngine;
using Drone;

namespace Shooter
{
    public class AttackState : State<Shooter>
    {
        readonly float attackTimeout = 1f;
        float timeSinceLastAttack = .6f;
        CommonPlayer player;
        public AttackState(Shooter enemyObject, StateController<Shooter> stateController, CommonPlayer player) : base(enemyObject, stateController)
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
                this.gameObject.Shoot(player.transform.position - this.gameObject.transform.position);
                
                timeSinceLastAttack = 0f;
            }
        }
    }

}

