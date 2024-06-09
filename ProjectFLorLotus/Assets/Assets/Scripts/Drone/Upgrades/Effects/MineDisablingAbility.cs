using Drone;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/MineDisablingAbility")]
public class MineDisablingAbilityBuff : PowerUpEffect
{
    public override void Apply(GameObject target)
    {

        if (!target.TryGetComponent<RepairPlayer>(out var repairPlayer)) return;

        repairPlayer.AddComponent<MineDisablingAbility>();
    }

    public class MineDisablingAbility : MonoBehaviour
    {
        
    }
}
