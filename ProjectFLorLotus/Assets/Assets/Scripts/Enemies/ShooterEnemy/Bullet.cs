using UnityEngine;

public class Bullet : MonoBehaviour
{
    float ttl = 2f;

    private void FixedUpdate() {
        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<HealthBar>().health -= 10;
            Destroy(gameObject);
        }
    }
}