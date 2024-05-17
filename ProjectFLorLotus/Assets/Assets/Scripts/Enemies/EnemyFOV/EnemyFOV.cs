using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField]
    private Transform EnemyObject;

    private void Awake()
    {
        if (!transform.parent.CompareTag("Enemy"))
        {
            throw new System.Exception(transform.parent.name + ": Enemy FOV can only be used on gameobjects of type enemy");
        }

        EnemyObject = transform.parent;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Light2D>().pointLightInnerAngle = EnemyObject.GetComponent<Enemy.Enemy>().viewAngle - EnemyObject.GetComponent<Enemy.Enemy>().viewAngle / 2;
        this.GetComponent<Light2D>().pointLightOuterAngle = EnemyObject.GetComponent<Enemy.Enemy>().viewAngle + 3f;
        this.GetComponent<Light2D>().pointLightInnerRadius = EnemyObject.GetComponent<Enemy.Enemy>().viewDistance - EnemyObject.GetComponent<Enemy.Enemy>().viewDistance / 2;
        this.GetComponent<Light2D>().pointLightOuterRadius = EnemyObject.GetComponent<Enemy.Enemy>().viewDistance;
        this.GetComponent<CircleCollider2D>().radius = EnemyObject.GetComponent<Enemy.Enemy>().viewDistance;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, EnemyObject.GetComponent<Enemy.Enemy>().facingDirection);
    }
}
