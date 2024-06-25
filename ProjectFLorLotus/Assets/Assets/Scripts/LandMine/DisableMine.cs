using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMine : MonoBehaviour
{

    [SerializeField]
    GameObject mineDisablingAbility;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.TryGetComponent<MineDisablingAbilityBuff.MineDisablingAbility>(out var mineDisablingAbility))
            {
                if (Input.GetKey(KeyCode.C))
                {
                    DisableLandMine();
                }
            }
        }
    }

    public void DisableLandMine()
    {
        mineDisablingAbility.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .6f);
        mineDisablingAbility.GetComponent<BoxCollider2D>().enabled = false;
        mineDisablingAbility.GetComponent<LandMine>().isEnabled = false;
        gameObject.SetActive(false);
    }

}
