using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaExplosion : MonoBehaviour
{

    Collider2D[] inBombRadius = null;
    [SerializeField] protected float explosionRadius;
    [SerializeField] private ParticleSystem bombParticle = default;
    private bool alreadyExploded;
    [SerializeField] AudioClip sfx;
    void Update()
    {
        if (!alreadyExploded && Input.GetKeyDown(KeyCode.X))
        {
            Explode();
        }
    }
    void Explode()
    {
        alreadyExploded = true;
        inBombRadius = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        bombParticle.Play();
        AudioSource.PlayClipAtPoint(sfx,transform.position);
        foreach (Collider2D e in inBombRadius)
        {
            if (e.CompareTag("Enemy"))
            {
                Destroy(e.gameObject,0.5f);            
            }
        }
        Destroy(gameObject,1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
