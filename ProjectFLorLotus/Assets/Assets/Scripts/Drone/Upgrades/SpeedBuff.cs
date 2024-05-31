using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drone;

[CreateAssetMenu(menuName = "PowerUps/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        
    target.GetComponent<CommonPlayer>()._playerSpeed += amount;
    target.GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
