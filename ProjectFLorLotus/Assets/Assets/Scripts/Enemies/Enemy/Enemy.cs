using StateMachine;
using UnityEngine;
namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        public Vector3 facingDirection = Vector3.right;

        public StateController<Enemy> stateController;
        public PatrolState patrolState;

        private void Awake()
        {
            stateController = new StateController<Enemy>();

            patrolState = new PatrolState(this, stateController);
        }

        private void Start()
        {
            stateController.Initialize(patrolState);
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
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new AttackState(this, stateController, other.gameObject.GetComponent<player_controller>()));
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new ChaseState(this, stateController, other.gameObject.GetComponent<player_controller>()));
            }
        }


    }
}