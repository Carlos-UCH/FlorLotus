using NodePathing;
using StateMachine;
using UnityEngine;
using Drone;
using System.Collections.Generic;
using System.Collections;

namespace Shooter
{
    public class Shooter : MonoBehaviour
    {
        private StateController<Shooter> stateController;
        private PatrolState patrolState;
        private Animator _EnemyAnimator;
        public float _EnemySpeed;
        private Rigidbody2D _EnemyRigidbody2D;

        [SerializeField]
        private Bullet bullet;

        [SerializeField]
        private float shootingPower = 1f;
        private Vector3 previousPosition;
        private float horizontalMovement;
        private float verticalMovement;
        private float horizontalMovement2;
        private float verticalMovement2;


        private void Awake()
        {
            stateController = new StateController<Shooter>();

            this.GetComponent<NodePath>().StartNodes(transform.position);
            patrolState = new PatrolState(this, stateController, GetComponent<NodePath>());
        }

        private void Start()
        {
            stateController.Initialize(patrolState);
            _EnemyRigidbody2D = GetComponent<Rigidbody2D>();
            _EnemyAnimator = GetComponent<Animator>();
            previousPosition = transform.position;
        }

        private void Update()
        {   

            stateController.currentState.FrameUpdate();
            //animation
            
            
            //Debug.Log();
            
        }

        private void FixedUpdate()
        {   
            Vector3 currentPosition = transform.position;
            Vector3 movementDelta = currentPosition - previousPosition;
            float horizontalMovement = (movementDelta.x);
            float verticalMovement = (movementDelta.y); // Use z para o eixo 
            stateController.currentState.PhysicsUpdate();
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

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //FindObjectOfType<AudioManager>().ToggleBattleMusic();
                FindObjectOfType<BattleManager>().AddEnemy(this.gameObject);
                stateController.SwitchState(new AttackState(this, stateController, other.gameObject.GetComponent<CommonPlayer>()));
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            //AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (other.gameObject.CompareTag("Player"))
            {   
                //audioManager.ToggleBattleMusic();
                FindObjectOfType<BattleManager>().RemoveEnemy(this.gameObject);
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