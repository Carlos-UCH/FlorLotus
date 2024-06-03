using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    Collider2D[] inBombRadius = null;
    [SerializeField] protected float ExplosionRadius;
    [SerializeField] private ParticleSystem bombParticle = default;
    [SerializeField] private float currentDistance = -1;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {  

            Explode();

        }

    }

    void Explode()
    {
        inBombRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);
        bombParticle.Play();
        foreach (Collider2D e in inBombRadius)
        {
            if (e.CompareTag("Enemy"))
            {
                e.GetComponent<MonoBehaviour>().enabled = false;
                StartCoroutine(Activate(e));
            }
       /*     if (e.CompareTag("Player"))
            { 
                Vector2 playerVector = e.GetComponent<Vector2>();
                Vector2.Distance(This, playerVector);
            
            }*/
        }

    }

    private IEnumerator Activate(Collider2D other)
    {
        yield return new WaitForSeconds(5);
        other.GetComponent<MonoBehaviour>().enabled = true;
    
    }

}