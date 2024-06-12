using UnityEngine;
using Drone;



[CreateAssetMenu(menuName = "PowerUps/healthBuff")]
public class HealthBuff : PowerUpEffect
{
    public float amount;

    public Sprite alteredHealthBar;

    public override void Apply(GameObject target)
    {
        target.GetComponent<CommonPlayer>().maxHealth += amount;
        target.GetComponent<CommonPlayer>().health = target.GetComponent<CommonPlayer>().maxHealth;
        target.GetComponent<CommonPlayer>().healthBar.sprite = alteredHealthBar;
    }
}
