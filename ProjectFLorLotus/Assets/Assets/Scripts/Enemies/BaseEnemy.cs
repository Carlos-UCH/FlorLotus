using StateMachine;
using UnityEngine;

namespace Enemy
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField]
        public Vector3 facingDirection = Vector3.right;

        public StateController<BaseEnemy> stateController;

        private void Awake()
        {
            stateController = new StateController<BaseEnemy>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            stateController.currentState.FrameUpdate();
        }

        private void FixedUpdate()
        {
            stateController.currentState.PhysicsUpdate();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
        }

        void OnCollisionExit2D(Collision2D other)
        {
        }

        void OnTriggerEnter2D(Collider2D other)
        {
        }

        void OnTriggerExit2D(Collider2D other)
        {
        }
    }
}