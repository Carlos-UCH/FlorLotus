using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    [SerializeField]bool isOnGround = false;
    GameObject bombObject;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject bombPrefab2;

    void Update()
    {
        if (!isOnGround && Input.GetKeyDown(KeyCode.Z))
                {
                isOnGround = true;
                bombObject = Instantiate(bombPrefab);
                bombObject.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1,0,0);
                }
        if (!isOnGround && Input.GetKeyDown(KeyCode.T))
        {
            isOnGround = true;
            bombObject = Instantiate(bombPrefab2);
            bombObject.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1,0,0);
            }
        
        if (bombObject == null)
        {
            isOnGround = false;
        }
}
}