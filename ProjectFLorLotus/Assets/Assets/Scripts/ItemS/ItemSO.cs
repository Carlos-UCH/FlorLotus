using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drone;

[CreateAssetMenu]
public class ItemSO : ScriptableObject

{

    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public void UseItems()
    {
        if (statToChange == StatToChange.health)
        {
            if (GameObject.Find("PlayerClass").GetComponent<CommonPlayer>().enabled == true)
            {
            GameObject.Find("PlayerClass").GetComponent<CommonPlayer>().ChangeHealth(amountToChangeStat);
            }
            else
            {
            GameObject.Find("RepairClass").GetComponent<CommonPlayer>().ChangeHealth(amountToChangeStat);
            }
            }

        }

    


    public enum StatToChange
    {
        none,
        health,
        energy
    };


}