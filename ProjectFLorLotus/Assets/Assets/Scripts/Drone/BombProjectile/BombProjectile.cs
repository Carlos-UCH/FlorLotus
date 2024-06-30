using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    [SerializeField] protected bool isOnGround = false;
    protected GameObject bombObject;
    [SerializeField] protected GameObject bombPrefab;
    [SerializeField] protected GameObject bombPrefab2;
    protected int bombExploded;
 
    public virtual void BombPlacing()
    {
        if (!isOnGround && Input.GetKeyDown(KeyCode.Z))
                {
                bombExploded = 1;
                isOnGround = true;
                bombObject = Instantiate(bombPrefab);
                bombObject.transform.position = GameObject.Find("PlayerClass").transform.position + new Vector3(1,0,0);
                }
        if (!isOnGround && Input.GetKeyDown(KeyCode.T))
            {
            bombExploded = 1;
            isOnGround = true;
            bombObject = Instantiate(bombPrefab2);
            bombObject.transform.position = GameObject.Find("PlayerClass").transform.position + new Vector3(1,0,0);
            }
        
        if (bombObject == null)
        {
        isOnGround = false;
        }
    }
}