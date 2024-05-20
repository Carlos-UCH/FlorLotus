using StateMachine;
using UnityEngine;
using Drone;

namespace TurretEnemy
{
    public class AttackState : State<TurretEnemy>
    {
        readonly float attackTimeout = .2f;
        float timeSinceLastAttack = -.4f;
        readonly Transform target;
        public AttackState(TurretEnemy enemyObject, StateController<TurretEnemy> stateController, Transform target) : base(enemyObject, stateController)
        {
            this.gameObject = enemyObject;
            this.stateController = stateController;
            this.target = target;
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
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack > attackTimeout)
            {
                this.gameObject.Shoot(target.transform.position - this.gameObject.transform.position);

                timeSinceLastAttack = 0f;
            }
        }

        public override void PhysicsUpdate()
        {
            this.gameObject.facingDirection = target.transform.position - this.gameObject.transform.position;
        }
    }
}