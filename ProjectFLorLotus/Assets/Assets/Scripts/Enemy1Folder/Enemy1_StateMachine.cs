using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// public enum EnemyState { Patrol, Chase, Attack }
public class Enemy1_StateMachine : MonoBehaviour
{

    public IEnemyState currentState;

    private void Start()
    {
        currentState = new PatrolState(this);
        currentState.StartState();
    }

    private void Update()
    {
        currentState.UpdateState();

        
        // // Update the behavior based on the current state
        // switch (currentState)
        // {
        //     case EnemyState.Patrol:

        //         // Implement behavior for the Patrol state
        //         Debug.Log("Enemy is Patrolling");
        //         break;

        //     case EnemyState.Chase:
        //         // Implement behavior for the Chase state
        //         Debug.Log("Enemy is Chasing");
        //         break;

        //     case EnemyState.Attack:
        //         // Implement behavior for the Attack state
        //         Debug.Log("Enemy is Attacking");
        //         break;
        // }


    }

    private void FixedUpdate() {
        currentState.FixedUpdate();
    }

    // // Method to transition to the Patrol state
    // public void StartPatrol()
    // {
    //     currentState = EnemyState.Patrol;
    // }

    // // Method to transition to the Chase state
    // public void StartChase()
    // {
    //     currentState = EnemyState.Chase;
    // }

    // // Method to transition to the Attack state
    // public void StartAttack()
    // {
    //     currentState = EnemyState.Attack;
    // }


}

