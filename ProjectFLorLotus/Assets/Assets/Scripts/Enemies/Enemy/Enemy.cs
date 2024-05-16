using StateMachine;
using UnityEngine;
namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        // FOV
        [Range(0, 360)]
        public float viewAngle;
        [Range(0, 10f)]
        public float viewDistance = 2f;
        public LayerMask targetMask;
        public LayerMask obstacleMask;
        // CHoose a direction
        [SerializeField]
        public Vector3 facingDirection = Vector3.right;


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

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(patrolState);
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (IsTargetInSight(other.transform) && stateController.currentState == patrolState)
                {
                    stateController.SwitchState(new ChaseState(this, stateController, other.gameObject.GetComponent<player_controller>()));
                }
                else if (!IsTargetInSight(other.transform) && stateController.currentState.GetType() == typeof(ChaseState))
                {
                    stateController.SwitchState(patrolState);
                }
            }
        }

        bool IsTargetInSight(Transform target)
        {
            Vector3 directionToTarget = target.position - transform.position;
            float angleToTarget = Vector3.Angle(this.facingDirection, directionToTarget);
            if (angleToTarget < viewAngle / 2f)
            {
                if (!Physics2D.Raycast(transform.position, directionToTarget, viewDistance, obstacleMask))
                {
                    return true;
                }
            }

            Debug.DrawLine(transform.position, transform.position + directionToTarget * viewDistance, Color.red);
            return false;
        }
    }
}