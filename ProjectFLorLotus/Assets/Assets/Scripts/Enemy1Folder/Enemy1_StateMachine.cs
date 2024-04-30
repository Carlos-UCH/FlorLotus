using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState { Patrol, Chase, Attack }
public class Enemy1_StateMachine : MonoBehaviour
{

    public EnemyState currentState;

    private void Start()
    {
        // Initialize the state machine with the initial state
        currentState = EnemyState.Patrol;
    }

    private void Update()
    {
        // Update the behavior based on the current state
        switch (currentState)
        {
            case EnemyState.Patrol:
                // Implement behavior for the Patrol state
                Debug.Log("Enemy is Patrolling");
                break;

            case EnemyState.Chase:
                // Implement behavior for the Chase state
                Debug.Log("Enemy is Chasing");
                break;

            case EnemyState.Attack:
                // Implement behavior for the Attack state
                Debug.Log("Enemy is Attacking");
                break;
        }


    }

    // Method to transition to the Patrol state
    public void StartPatrol()
    {
        currentState = EnemyState.Patrol;
    }

    // Method to transition to the Chase state
    public void StartChase()
    {
        currentState = EnemyState.Chase;
    }

    // Method to transition to the Attack state
    public void StartAttack()
    {
        currentState = EnemyState.Attack;
    }


}

