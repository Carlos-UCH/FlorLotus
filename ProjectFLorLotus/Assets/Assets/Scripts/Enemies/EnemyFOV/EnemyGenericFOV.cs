using Enemy;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(BaseEnemy))]
[RequireComponent(typeof(Light2D))]
public class EnemyGenericFOV : MonoBehaviour
{
    // FOV
    [Range(0, 360)]
    public float viewAngle = 60;
    [Range(0, 16f)]
    public float viewDistance = 5f;

    [SerializeField]
    private Transform EnemyObject;

    [SerializeField]
    private Transform entityInSight;

    private void Awake()
    {
        EnemyObject = transform.parent;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Light2D>().pointLightInnerAngle = this.viewAngle;
        this.GetComponent<Light2D>().pointLightOuterAngle = this.viewAngle + this.viewAngle / 4;
        this.GetComponent<Light2D>().pointLightInnerRadius = this.viewDistance - this.viewDistance / 2;
        this.GetComponent<Light2D>().pointLightOuterRadius = this.viewDistance;
        this.GetComponent<CircleCollider2D>().radius = this.viewDistance;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, EnemyObject.GetComponent<BaseEnemy>().facingDirection);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.AlertEntityVanished();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        EnemyGenericFOV fov = this.GetComponentInChildren<EnemyGenericFOV>();

        if (other.gameObject.CompareTag("Player"))
        {
            if (fov.IsTargetInSight(other.transform))
            {
                this.entityInSight = other.transform;
                this.AlertEntityInSight(other.transform);
            }
            else if (!fov.IsTargetInSight(other.transform) && this.entityInSight != null)
            {
                this.AlertEntityVanished();
                this.entityInSight = null;
            }
        }
    }

    public bool IsTargetInSight(Transform target)
    {
        Vector3 directionToTarget = target.position - transform.position;
        float angleToTarget = Vector3.Angle(EnemyObject.GetComponent<BaseEnemy>().facingDirection, directionToTarget);
        if (angleToTarget < viewAngle / 2f)
        {
            RaycastHit2D[] rayHits = Physics2D.RaycastAll(transform.position, directionToTarget, viewDistance);
            foreach (var rayHit in rayHits)
            {
                if (rayHit.collider.CompareTag("Collider"))
                {
                    return false;
                }
                if (rayHit.collider != null && rayHit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void AlertEntityInSight(Transform entity)
    {
        this.EnemyObject.GetComponent<BaseEnemy>().FOVEnterSight(entity);
    }

    public void AlertEntityVanished()
    {
        this.EnemyObject.GetComponent<BaseEnemy>().FOVExitSight();
    }
}
