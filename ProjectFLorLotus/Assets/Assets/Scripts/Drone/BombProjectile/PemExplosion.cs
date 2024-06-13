using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    Collider2D[] inBombRadius = null;
    [SerializeField] protected float explosionRadius;
    [SerializeField] private ParticleSystem bombParticle = default;
    private bool alreadyExploded;
    [SerializeField] AudioClip sfx,sfx2;

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
        AudioSource.PlayClipAtPoint(sfx,transform.position);
        bombParticle.Play();
        foreach (Collider2D e in inBombRadius)
        {
            if (e.CompareTag("Enemy"))
            {
                e.GetComponent<MonoBehaviour>().enabled = false;
                StartCoroutine(Activate(e));
            }
        }
        AudioSource.PlayClipAtPoint(sfx2,transform.position);
        Destroy(gameObject,6);
    }
    private IEnumerator Activate(Collider2D other)
    {
        yield return new WaitForSeconds(5);
        other.GetComponent<MonoBehaviour>().enabled = true;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius
);
    }
}
