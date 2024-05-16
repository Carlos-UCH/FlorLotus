using System.Collections;
using System.Collections.Generic;
using Drone;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace Drone{
public class RepairPlayer : CommonPlayer
{

    [SerializeField] private int changeHealthValue;
    private CommonPlayer targetedPlayer;
    private int frameCount = 0;

    void OnCollisionStay2D(Collision2D other)
    {
        if ( other.gameObject.CompareTag("Player"))
        {

          if (Input.GetKey(KeyCode.E) && frameCount % 30 == 0)
          {
           HealOtherDrone(targetedPlayer = other.gameObject.GetComponent<CommonPlayer>());
          }
    
        }
    frameCount++;
    }

    void HealOtherDrone(CommonPlayer player)
    {
       if (player.health < player.maxHealth)
       {
        player.health += changeHealthValue;
       }

    }



}


}
