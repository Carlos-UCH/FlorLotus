using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1_Damage : MonoBehaviour
{

    public HealthBar vida;
    public float damage;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.CompareTag("Player")){
   
            other.gameObject.GetComponent<HealthBar>().health -= damage;
        }
    }
}
