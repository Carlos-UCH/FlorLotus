using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Drone
{

    public class CommonPlayer : MonoBehaviour
    {
        /*************************
           * PLAYER ATRIBUTES *
        *************************/
        [SerializeField] public float health;
        [SerializeField] public float maxHealth;
        [SerializeField] public Image healthBar;
        [SerializeField] public float energy;
        [SerializeField] public float maxEnergy;
        [SerializeField] public Image energyBar;
        public float _playerSpeed;
        private Rigidbody2D _playerRigidbody2D;
        private Animator _playerAnimator;
        private float _playerInitialSpeed;
        public float _playerRunSpeed;
        private Vector2 _playerDirection;
        private int collcheck;
        private InventoryManager inventoryManager;

        /*************************
        * MONOBEHAVIOUR FUNCTIONS *
        *************************/
        protected void Start()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();

            _playerAnimator = GetComponent<Animator>();

            _playerInitialSpeed = _playerSpeed;

        }
        protected void Update()
        {

            //HealthBar//
            PlayerDie();
            PlayerIsFull();
            HealthBarModifier();
            //PlayerDirectionSetter//
            PlayerWalk();
            PlayerMovementVerification();
            playerRun();
        }
        void FixedUpdate()
        {
            _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
        }

        /*************************
            * PLAYER METHODS *
        *************************/
        int direction()
        {
            if (_playerDirection.x > 0)
            {
                return 1;
            }
            else if (_playerDirection.x < 0)
            {
                return 2;
            }
            else if (_playerDirection.y > 0)
            {
                return 3;
            }
            else if (_playerDirection.y < 0)
            {
                return 4;
            }

            return 0;
        }
        void PlayerWalk()
        {
            _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        void PlayerMovementVerification()
        {
            if (_playerDirection.sqrMagnitude > 0)
            {
                _playerAnimator.SetInteger("Movement", direction());

            }
            else
            {
                _playerAnimator.SetInteger("Movement", 0);
            }
        }
        void playerRun()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerSpeed = _playerRunSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _playerSpeed = _playerInitialSpeed;
            }
        }
        public void AddHealth(int amountToChange)
        {
            if (health < maxHealth)
            {
                health += amountToChange;
            }
        }
        public void RemoveHealth(int amountToChange)
        {
            health -= amountToChange;
        }
        void PlayerDie()
        {
            if (health <= 0)
        {   GetComponent<CommonPlayer>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
        }
        void PlayerIsFull()
        {
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public void HealthBarModifier()
            {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

            }
        }
    }
