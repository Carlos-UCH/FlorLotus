using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drone;

public class LandMine : MonoBehaviour
{
 
 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CommonPlayer>().health -= 90;
            Destroy(gameObject);
        }

    }

}
