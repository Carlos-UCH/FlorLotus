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
    public bool isCollisionTrue = false;
    public float timeCount = 0.0f;
    [SerializeField] public float timeToHeal = 3.0f;
    public GameObject healingEffect;
    public bool isHealActive ;

    new void Update()
    {
      base.Update();
      if (isCollisionTrue)
      {
        if (Input.GetKey(KeyCode.E))
        {
        if (targetedPlayer.health != targetedPlayer.maxHealth)
          {
            timeCount += Time.deltaTime;
          if (!isHealActive)
            {
            StartHealingEffect(timeToHeal);
            }
          if (timeCount >= timeToHeal)
            {
              HealOtherDrone(targetedPlayer);    
            }
          }
        }
        else
        {
        isHealActive = false;
        healingEffect.SetActive(false);
        timeCount = 0;  
        }
      }
      else
      {
        isHealActive = false;
        healingEffect.SetActive(false);
        timeCount =  0;
      }
    }

  void OnCollisionEnter2D(Collision2D other)
  {
    isCollisionTrue = true;
    targetedPlayer = other.gameObject.GetComponent<CommonPlayer>();
  }
  void OnCollisionExit2D( Collision2D other)
  {
    isCollisionTrue = false;
  }
  void HealOtherDrone(CommonPlayer player)
  {
    if (player.health < player.maxHealth)
      {
        player.health = player.maxHealth;
        targetedPlayer.HealthBarModifier();
        isHealActive = false;
        healingEffect.SetActive(false);
       } 
     timeCount = 0;
    }
  public void StartHealingEffect(float duration)
  {
    isHealActive = true;
    healingEffect.SetActive(true);
    healingEffect.transform.Find("RadialProgressBar").GetComponent<CircularProgressBar>().ActivateCountdown(duration);
  }

}


}
