using UnityEngine;
using Drone;



[CreateAssetMenu(menuName = "PowerUps/energyBuff")]
public class EnergyBuff : PowerUpEffect
{
    public float amount;

    public Sprite alteredHealthBar;

    public override void Apply(GameObject target)
    {
        target.GetComponent<CommonPlayer>().maxEnergy += amount;
        target.GetComponent<CommonPlayer>().energy = target.GetComponent<CommonPlayer>().maxEnergy;
        target.GetComponent<CommonPlayer>().energyBar.sprite = alteredHealthBar;
    }
}
