using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace Drone
{

    public class CommonPlayer : BombProjectile
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
        public bool playerIsRunning ;
        private bool playerIsWalking ;
        public float walkingCost ;
        [SerializeField]private float runningCost ;
        [SerializeField] protected float energyPassiveRegen ;
        public float _playerSpeed;
        private Rigidbody2D _playerRigidbody2D;
        private Animator _playerAnimator;
        public float _playerInitialSpeed;
        public float playerInitialRunSpeed;
        public float _playerRunSpeed;
        private Vector2 _playerDirection;
        private int collcheck;
        private InventoryManager inventoryManager;
        [SerializeField] protected GameObject walkingPrefab;
        [SerializeField] protected GameObject runningPrefab;
        private GameObject currentSound, currentSound2;

        /*************************
        * MONOBEHAVIOUR FUNCTIONS *
        *************************/
        protected void Start()
        {
            _playerRigidbody2D = GetComponent<Rigidbody2D>();
            _playerAnimator = GetComponent<Animator>();
            _playerInitialSpeed = _playerSpeed;
            playerInitialRunSpeed = _playerRunSpeed;
        }   
        protected void Update()
        {
            //HealthBar//
            PlayerDie();
            PlayerIsFull();
            BarModifiers();
            //PlayerDirectionSetter//
            PlayerMovementVerification();
            playerRun();
            PlayerWalk();
            EnergyDrain();
            EnergyRecovery();
            EnergyCheck();
            //Bomb Methods
            BombPlacing();
            BombCost();
            //AudioControl
            AudioController();
          
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
                playerIsWalking = true;
                
            }
            else
            {
                _playerAnimator.SetInteger("Movement", 0);
                playerIsWalking = false;
            }
        }
        void playerRun()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerSpeed = _playerRunSpeed;
                playerIsRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _playerSpeed = _playerInitialSpeed;
                playerIsRunning = false;
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
        {   
            GetComponent<CommonPlayer>().enabled = false;
            gameObject.tag = "DeadPlayer";
        }

        }

    
        void PlayerIsFull()
        {
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
        }
        public void BarModifiers()
            {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
            energyBar.fillAmount = Mathf.Clamp(energy / maxEnergy, 0, 1);
            }
        public void EnergyDrain()
            {
                if (energy > 0)
                    {
                        if (playerIsWalking)
                            {
                                energy -= walkingCost * Time.deltaTime;
                            }
                        if (playerIsRunning)
                            {
                                energy -= runningCost * Time.deltaTime;
                            }
                    }
            }        
        public void EnergyRecovery()
            {
                if (!playerIsWalking && energy < maxEnergy)
                    {
                        energy += energyPassiveRegen * Time.deltaTime;
                    }
            }
        void EnergyCheck()
            {
            if (energy <= 0)
                {
                    _playerSpeed = 0;
                    _playerRunSpeed = 0;
                }
            if (energy >= walkingCost && energy <= runningCost)
                {
                    _playerSpeed = _playerInitialSpeed;
                }
            else
                {
                    _playerRunSpeed = playerInitialRunSpeed;
                }    
            }    
        public virtual void BombCost()
        {
            if (bombExploded == 1)
            {
                energy -= maxEnergy * 0.7f;
                bombExploded = 0;
            }
            else if (bombExploded == 2)
            {
                energy -= maxEnergy * 0.9f;
                bombExploded = 0;
            }
        }

        public void AudioController()
        {
            if (playerIsWalking && !playerIsRunning && energy > walkingCost  && currentSound == null)
            {
                Destroy(currentSound2);
                currentSound = Instantiate(walkingPrefab, transform.position, Quaternion.identity);
            }
            else if (playerIsRunning && energy > runningCost && currentSound2 == null)
            {
                Destroy(currentSound);
                currentSound2 = Instantiate(runningPrefab, transform.position, Quaternion.identity);
            }
            if (!playerIsWalking || gameObject.GetComponent<MonoBehaviour>().enabled == false)
            {
                Destroy(currentSound);
                Destroy(currentSound2);
            }
        }
     
     
}
}