using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drone;

public class LandMine : MonoBehaviour
{
 
 public ParticleSystem particleSystem; 
 void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CommonPlayer>().health -= 90;
            DestroyLandMine();
        }

    }

    public void DestroyLandMine()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }

}
