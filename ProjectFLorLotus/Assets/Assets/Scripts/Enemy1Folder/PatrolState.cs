using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    readonly MonoBehaviour enemyObject;

    [SerializeField]
    float speed = 1;

    [SerializeField]
    float range = 5;
    
    [SerializeField]
    float maxDistance = .1f;
    
    Vector3 wayPoint;

    public PatrolState(MonoBehaviour enemyObject) {
        this.enemyObject = enemyObject;
    }

    public void EndState()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        Debug.Log(Vector3.Distance(enemyObject.transform.position, wayPoint));
        enemyObject.transform.position = Vector3.MoveTowards(enemyObject.transform.position, wayPoint, speed * Time.deltaTime);
        if(Vector3.Distance(enemyObject.transform.position, wayPoint) < range)
        {
            SetNewDestination();    
        }
    }   

    public void StartState()
    {
        Debug.Log("Start Patrol");
        SetNewDestination();
    }

    public void UpdateState()
    {

    }

    void SetNewDestination()
    {
        wayPoint = new Vector3(Random.Range(enemyObject.transform.position.x*-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
        Debug.DrawLine(wayPoint, wayPoint * 1.1f, Color.red, 10f);
    }
}
