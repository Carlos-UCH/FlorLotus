using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    [SerializeField]
    float speed; 

     [SerializeField]
    float range; 

     [SerializeField]

     Vector2 wayPoint;

    float maxDistance;
    public void EndState()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void StartState()
    {
        SetNewDestination();
    }

    public void Update()
    {
       
       
    }

    void SetNewDestination(){
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}
