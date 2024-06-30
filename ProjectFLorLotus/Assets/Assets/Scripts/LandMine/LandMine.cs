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

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.TryGetComponent<MineDisablingAbilityBuff.MineDisablingAbility>(out var mineDisablingAbility))
            {
                if (Input.GetKey(KeyCode.C))
                {
                    DisableLandMine();
                }
            }
        }
    }

    public void DetonateLandMine()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public void DisableLandMine()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .6f);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        isEnabled = false;
    }
}
