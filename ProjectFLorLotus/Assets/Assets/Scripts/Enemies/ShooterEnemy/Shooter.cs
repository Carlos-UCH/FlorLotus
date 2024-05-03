using NodePathing;
using StateMachine;
using UnityEngine;

namespace Shooter
{
    public class Shooter : MonoBehaviour
    {
        private StateController<Shooter> stateController;
        private PatrolState patrolState;

        [SerializeField]
        private Bullet bullet;

        [SerializeField]
        private float shootingPower = 1f;

        private void Awake()
        {
            stateController = new StateController<Shooter>();

            this.GetComponent<NodePath>().StartNodes(transform.position);
            patrolState = new PatrolState(this, stateController, GetComponent<NodePath>());
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

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new AttackState(this, stateController, other.gameObject.GetComponent<player_controller>()));
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(patrolState);
            }
        }

        public void Shoot(Vector3 direction)
        {
            var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<Rigidbody2D>().velocity = direction * shootingPower;
        }
    }
}