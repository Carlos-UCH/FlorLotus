using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] public GameObject[] enemiesSpawned;
    [SerializeField] protected GameObject shootingEnemy;
    [SerializeField] protected GameObject meleeEnemy;
    [SerializeField] protected GameObject turretBoss;
    [SerializeField] protected GameObject dumPrefab;
    [SerializeField] protected GameObject deathPrefab;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected int currentWave;
    [SerializeField] protected bool waveSpawned =false ;
    [SerializeField]private int numberofEnemies;
    [SerializeField] private GameObject restartCanva;
    [SerializeField] protected AudioClip[] bossSounds;
    [SerializeField] protected bool perWaveChewch = false;
    private bool bossStarted = false;
    private int waveEnemies ;
    private float x,y = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }


    void Update()
    {
        WavesControl();
        NumberofEnemies();
        BossDeath();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (currentWave == 0 & other.gameObject.CompareTag("Player"))
        {
            currentWave = 1;
        }
    }

    void WavesControl()
    {

        if (currentWave == 1 && !waveSpawned)
        {
            bossStarted = true;
            audioSource.Stop();
            audioSource.clip = bossSounds[0];
            audioSource.Play();
            numberofEnemies = 5;
            waveEnemies = numberofEnemies;
            waveSpawned = true;
            EnemySpawn();
                    
        }  
        else if (currentWave == 2 && !waveSpawned)
        {
            audioSource.Stop();
            audioSource.clip = bossSounds[1];
            audioSource.Play();
            numberofEnemies = 10;
            waveEnemies = numberofEnemies;
            waveSpawned = true;
            EnemySpawn();
                 
        }   
        else if (currentWave == 3 && !waveSpawned)
        {
            audioSource.Stop();
            audioSource.clip = bossSounds[2];
            audioSource.Play();
            numberofEnemies = 20;
            waveEnemies = numberofEnemies;
            waveSpawned = true;
            EnemySpawn();
        }
    }
    void NumberofEnemies()
    {
        if (bossStarted)
        {
            if (currentWave > 0){
                for (int i = 0; i < waveEnemies; i++)
                {
                    if (enemiesSpawned[i] == null)
                    {
                        enemiesSpawned[i] = Instantiate(dumPrefab);
                        numberofEnemies--;
                    }
                }
            }
            if (numberofEnemies <= 0)
            {
                for (int i = 0; i < waveEnemies; i++)
                {
                    Destroy(enemiesSpawned[i]);
                }
                currentWave++;
                x = 0;
                y = 0;
                waveSpawned = false;
            }
        }
    }
    void BossDeath()
        {
        if (currentWave == 4)
            {
            Instantiate(deathPrefab);
            audioSource.Stop();
            audioSource.clip = bossSounds[3];
            audioSource.Play();
            Invoke("BossDeathScene", 7);
            }

        }
    void BossDeathScene()
    {
        Time.timeScale = 0;
        restartCanva.SetActive(true);
        Destroy(gameObject);
    }

    void EnemySpawn()
    {
        if (currentWave ==1)
            {
                for (int i = 0; i < 5; i++)
                    {
                        if (i %2 == 0)
                        {
                        x = x + 0.25f;
                        y = y + 0.25f;
                        }
                        else 
                        {
                            x  = -x - 0.25f;
                            y = -y - 0.25f;
                        }
                        enemiesSpawned[i] = Instantiate(meleeEnemy);
                        enemiesSpawned[i].transform.position = GameObject.FindWithTag("Boss").transform.position + new Vector3(x,y,0);
                        enemiesSpawned[i].tag = "Enemy";
                    } 
            }
        else if (currentWave == 2)
            {
                for (int i = 0; i < 10; i++)
                    {
                        if (i %2 == 0)
                        {
                        x = x + 0.25f;
                        y = y + 0.25f;
                        }
                        else 
                        {
                            x  = -x - 0.25f;
                            y = -y - 0.25f;
                        }
                        enemiesSpawned[i] = Instantiate(meleeEnemy);
                        enemiesSpawned[i].transform.position = GameObject.FindWithTag("Boss").transform.position + new Vector3(x,y,0);
                        enemiesSpawned[i].tag = "Enemy";
                    }  
            }
        else if (currentWave == 3)
            {
                for (int i = 0; i < 20; i++)
                {
                    if (i %2 == 0)
                        {
                        x = x + 0.25f;
                        y = y + 0.25f;
                        }
                        else 
                        {
                            x  = -x - 0.25f;
                            y = -y - 0.25f;
                        }
                        enemiesSpawned[i] = Instantiate(meleeEnemy);
                        enemiesSpawned[i].transform.position = GameObject.FindWithTag("Boss").transform.position + new Vector3(x,y,0);
                        enemiesSpawned[i].tag = "Enemy";

                    if (i == 18)
                    {
                        x = 3;
                        enemiesSpawned[i] = Instantiate(turretBoss);
                        enemiesSpawned[i].transform.position = GameObject.FindWithTag("Boss").transform.position + new Vector3(x,0,0);
                        enemiesSpawned[i].tag = "Enemy";
                    }
                    if (i ==19)
                    {
                        x = -3;
                        enemiesSpawned[i] = Instantiate(turretBoss);
                        enemiesSpawned[i].transform.position = GameObject.FindWithTag("Boss").transform.position + new Vector3(x,0,0);
                        enemiesSpawned[i].tag = "Enemy";
                    }
                    }
                }  
            }

    }


            

