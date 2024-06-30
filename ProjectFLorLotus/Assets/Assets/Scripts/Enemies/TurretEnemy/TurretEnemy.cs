using Enemy;
using UnityEngine;

namespace TurretEnemy
{
    public class TurretEnemy : BaseEnemy
    {
        [SerializeField]
        private Bullet bullet;

        [SerializeField]
        [Range(0f, 1f)]
        private float shootingPower = 1f;
        //anim

        private Vector3 previousPosition;
        private float horizontalMovement;
        private float verticalMovement;
        private Animator _EnemyAnimator;
        public float _EnemySpeed;
        private float horizontalMovement2;
        private float verticalMovement2;


        public new StateMachine.StateController<TurretEnemy> stateController;
        private void Start(){
            _EnemyAnimator = GetComponent<Animator>();
            previousPosition = transform.position;
        }

        protected override void Awake()
        {
            stateController = new StateMachine.StateController<TurretEnemy>();
            stateController.Initialize(new PatrolState(this, stateController));
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
            ;
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

        public override void FOVEnterSight(Transform entityInFOV)
        {
            if (entityInFOV.CompareTag("Player") && this.stateController.currentState.GetType() == typeof(PatrolState))
            {
                FindObjectOfType<BattleManager>().AddEnemy(this.gameObject);
                //FindObjectOfType<AudioManager>().ToggleBattleMusic();
                this.stateController.SwitchState(new AttackState(this, stateController, entityInFOV));
            }
        }

        public override void FOVExitSight()
        {
            //FindObjectOfType<AudioManager>().ToggleBattleMusic();
            FindObjectOfType<BattleManager>().RemoveEnemy(this.gameObject);
            this.stateController.SwitchState(new PatrolState(this, stateController));
        }

        public void Shoot(Vector3 direction)
        {
            var bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized * shootingPower * 10;
        }
    }
}
