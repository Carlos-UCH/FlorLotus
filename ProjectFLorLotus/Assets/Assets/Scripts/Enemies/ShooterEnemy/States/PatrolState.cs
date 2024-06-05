using NodePathing;
using StateMachine;
using UnityEngine;

namespace Shooter
{
    public class PatrolState : State<Shooter>
    {
        public NodePath path;
        private Vector3 wayPoint;

        public PatrolState(Shooter shooterObject, StateController<Shooter> stateController, NodePath path) : base(shooterObject, stateController)
        {
            this.gameObject = shooterObject;
            this.stateController = stateController;
            this.path = path;
        }

        public override void Enter()
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            SetNewDestination();
        }

        public override void Exit()
        {
        }

        public override void PhysicsUpdate()
        {
            if (Vector3.Distance(gameObject.transform.position, wayPoint) < 0.1f)
            {
                SetNewDestination();
            }
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, wayPoint, 3f * Time.deltaTime);
        }

        public override void FrameUpdate()
        {
        }

        void SetNewDestination()
        {
            Vector3 newDestination = path.CycleNodes();
            wayPoint = newDestination;
        }
    }
}
