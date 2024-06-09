
using UnityEngine;

namespace Drone
{
  public class RepairPlayer : CommonPlayer
  {
    /*************************
       * REPAIR ATRIBUTES *
     *************************/
    [SerializeField] private int changeHealthValue;
    private CommonPlayer targetedPlayer;
    public bool isCollisionTrue = false;
    public float timeCount = 0.0f;
    [SerializeField] public float timeToHeal = 3.0f;
    [SerializeField] public float costToHeal;
    public GameObject healingEffect; public bool isHealActive;
    /*************************
       * MONOBEHAVIOUR METHODS *
     *************************/
    new void Update()
    {
      base.Update();
      HealDroneUpdateFunction();
    }
    /*************************
       * REPAIR METHODS *
     *************************/
    void HealDroneUpdateFunction()
    {
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
        timeCount = 0;
      }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
      isCollisionTrue = true;
      targetedPlayer = other.gameObject.GetComponent<CommonPlayer>();
    }
    void OnCollisionExit2D(Collision2D other)
    {
      isCollisionTrue = false;
    }
    void HealOtherDrone(CommonPlayer player)
    {
      if (player.health < player.maxHealth)
      {
        player.health = player.maxHealth;
        targetedPlayer.BarModifiers();
        isHealActive = false;
        healingEffect.SetActive(false);
        energy = 0;
        //energy -= costToHeal;
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
