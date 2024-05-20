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

        [SerializeField] public float health;
        [SerializeField] public float maxHealth;
        [SerializeField] public Image healthBar;
        private Rigidbody2D _playerRigidbody2D;
        public float _playerSpeed;
        private Animator _playerAnimator;
        private float _playerInitialSpeed;
        public float _playerRunSpeed;
        private Vector2 _playerDirection;
        private int collcheck;
        private InventoryManager inventoryManager;

        void Start()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();

            _playerAnimator = GetComponent<Animator>();

            _playerInitialSpeed = _playerSpeed;

        }

        protected void Update()
        {

            //HealthBar//
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
            if (health <= 0)
            {
                GetComponent<CommonPlayer>().enabled = false;
                Destroy(gameObject, 1.0f);

            }

            //PlayerDirectionSetter//
            _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_playerDirection.sqrMagnitude > 0)
            {
                _playerAnimator.SetInteger("Movement", direction());

            }
            else
            {
                _playerAnimator.SetInteger("Movement", 0);
            }
            playerRun();
        }


        void FixedUpdate()
        {
            _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);

        }

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

        public void ChangeHealth(int amountToChange)
        {
            if (health < maxHealth)
            {
                health += amountToChange;
            }
        }
    }
}