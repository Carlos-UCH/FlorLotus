using StateMachine;
using UnityEngine;

namespace Enemy
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        public Vector3 facingDirection = Vector3.right;

        public StateController<BaseEnemy> stateController;

        protected virtual void Awake()
        {
            stateController = new StateController<BaseEnemy>();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            stateController.currentState.FrameUpdate();
        }

        protected virtual void FixedUpdate()
        {
            stateController.currentState.PhysicsUpdate();
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
        }

        protected virtual void OnCollisionExit2D(Collision2D other)
        {
        }

        public abstract void FOVEnterSight(Transform entityInFOV);
        public abstract void FOVExitSight();
    }
}