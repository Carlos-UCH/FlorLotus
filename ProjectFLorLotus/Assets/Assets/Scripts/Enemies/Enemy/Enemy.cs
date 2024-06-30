using StateMachine;
using UnityEngine;
using Drone;
namespace Enemy
{
    public class Enemy : BaseEnemy
    {
        public PatrolState patrolState;
        //anim
        private Vector3 previousPosition;
        private float horizontalMovement;
        private float verticalMovement;
        private Animator _EnemyAnimator;
        public float _EnemySpeed;
        private float horizontalMovement2;
        private float verticalMovement2;

        public new StateController<Enemy> stateController;

        protected override void Awake()
        {
            stateController = new StateController<Enemy>();

            patrolState = new PatrolState(this, stateController);
        }

        protected override void Start()
        {
            stateController.Initialize(patrolState);
            _EnemyAnimator = GetComponent<Animator>();
            previousPosition = transform.position;
        }

        protected override void Update()
        {
            stateController.currentState.FrameUpdate();
        }

        protected override void FixedUpdate()
        {
            stateController.currentState.PhysicsUpdate();
            Vector3 currentPosition = transform.position;
            Vector3 movementDelta = currentPosition - previousPosition;
            float horizontalMovement = (movementDelta.x);
            float verticalMovement = (movementDelta.y); // Use z para o eixo 
            currentPosition = transform.position;
            movementDelta = currentPosition - previousPosition;
            
            previousPosition = currentPosition;
            //float GetMovementValue(float value)
            //{
            //// Retorna 1 se o valor for positivo, -1 se for negativo e 0 se for zero.
            //return Mathf.Approximately(value, 0f) ? 0 : Mathf.Sign(value);
            //}
            Vector3 movement = new Vector3(horizontalMovement2, verticalMovement2,0f);

            _EnemyAnimator.SetFloat("Horizontal", movementDelta.x);
            _EnemyAnimator.SetFloat("Vertical", movementDelta.y);
            _EnemyAnimator.SetFloat("Speed", movement.magnitude);

            transform.position = transform.position + movement * _EnemySpeed * Time.deltaTime;
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new AttackState(this, stateController, other.gameObject.GetComponent<CommonPlayer>()));
            }
        }

        protected override void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                stateController.SwitchState(new ChaseState(this, stateController, other.gameObject.GetComponent<CommonPlayer>()));
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //FindObjectOfType<AudioManager>().ToggleBattleMusic();
                FindObjectOfType<BattleManager>().AddEnemy(this.gameObject);
                stateController.SwitchState(new ChaseState(this, stateController, other.gameObject.GetComponent<CommonPlayer>()));
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //FindObjectOfType<AudioManager>().ToggleBattleMusic();
                FindObjectOfType<BattleManager>().RemoveEnemy(this.gameObject);
                stateController.SwitchState(patrolState);
            }
        }

        public override void FOVEnterSight(Transform entityInFOV)
        {
            throw new System.NotImplementedException();
        }

        public override void FOVExitSight()
        {
            throw new System.NotImplementedException();
        }
    }
}