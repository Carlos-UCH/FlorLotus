using StateMachine;
using UnityEngine;
namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private StateController<Enemy> stateController;
        private PatrolState patrolState;

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

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new ChaseState(this, stateController, other.gameObject.GetComponent<player_controller>()));
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(patrolState);
            }
        }
    }
}