using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drone;

public class LandMine : MonoBehaviour
{

    public bool isEnabled = true;

    public new ParticleSystem particleSystem;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (isEnabled && other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<CommonPlayer>().health -= 90;
            DetonateLandMine();
        }
    }

    public void DetonateLandMine()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
