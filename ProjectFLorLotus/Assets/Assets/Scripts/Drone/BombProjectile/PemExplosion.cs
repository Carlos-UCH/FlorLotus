using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    Collider2D[] inBombRadius = null;
    [SerializeField] protected float ExplosionRadius;
    [SerializeField] private ParticleSystem bombParticle = default;
    private bool alreadyExploded;

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
        inBombRadius = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);
        bombParticle.Play();
        foreach (Collider2D e in inBombRadius)
        {
            if (e.CompareTag("Enemy"))
            {
                e.GetComponent<MonoBehaviour>().enabled = false;
                StartCoroutine(Activate(e));
            }
        }
        Destroy(gameObject,6);
    }
    private IEnumerator Activate(Collider2D other)
    {
        yield return new WaitForSeconds(5);
        other.GetComponent<MonoBehaviour>().enabled = true;
    }
}
