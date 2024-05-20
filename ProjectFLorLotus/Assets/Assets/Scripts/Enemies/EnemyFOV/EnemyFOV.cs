using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyFOV : MonoBehaviour
{
    // FOV
    [Range(0, 360)]
    public float viewAngle = 60;
    [Range(0, 10f)]
    public float viewDistance = 5f;

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
        this.GetComponent<Light2D>().pointLightInnerAngle = this.viewAngle;
        this.GetComponent<Light2D>().pointLightOuterAngle = this.viewAngle + this.viewAngle / 4;
        this.GetComponent<Light2D>().pointLightInnerRadius = this.viewDistance - this.viewDistance / 2;
        this.GetComponent<Light2D>().pointLightOuterRadius = this.viewDistance;
        this.GetComponent<CircleCollider2D>().radius = this.viewDistance;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, EnemyObject.GetComponent<Enemy.Enemy>().facingDirection);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyObject.GetComponent<Enemy.Enemy>().GetComponent<Enemy.Enemy>().stateController.SwitchState(EnemyObject.GetComponent<Enemy.Enemy>().patrolState);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        EnemyFOV fov = this.GetComponentInChildren<EnemyFOV>();

        // if (other.gameObject.CompareTag("Player"))
        // {
        //     if (fov.IsTargetInSight(other.transform) && EnemyObject.GetComponent<Enemy.Enemy>().stateController.currentState == EnemyObject.GetComponent<Enemy.Enemy>().patrolState)
        //     {
        //         EnemyObject.GetComponent<Enemy.Enemy>().stateController.SwitchState(new Enemy.ChaseState(EnemyObject.GetComponent<Enemy.Enemy>(), EnemyObject.GetComponent<Enemy.Enemy>().stateController, other.gameObject.GetComponent<player_controller>()));
        //     }
        //     else if (!fov.IsTargetInSight(other.transform) && EnemyObject.GetComponent<Enemy.Enemy>().stateController.currentState.GetType() == typeof(ChaseState))
        //     {
        //         EnemyObject.GetComponent<Enemy.Enemy>().stateController.SwitchState(EnemyObject.GetComponent<Enemy.Enemy>().patrolState);
        //     }
        // }
    }

    public bool IsTargetInSight(Transform target)
    {
        Vector3 directionToTarget = target.position - transform.position;
        Debug.Log(directionToTarget);
        float angleToTarget = Vector3.Angle(EnemyObject.GetComponent<Enemy.Enemy>().facingDirection, directionToTarget);
        if (angleToTarget < viewAngle / 2f)
        {
            if (!Physics2D.Raycast(transform.position, directionToTarget, viewDistance).collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }

        Debug.DrawLine(transform.position, transform.position + directionToTarget * viewDistance, Color.red);
        return false;
    }
}
