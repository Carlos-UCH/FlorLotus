using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveSalaBoss : MonoBehaviour
{
    public GameObject key;
    public GameObject porta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
            Destroy(key);
            Destroy(porta);

    }
}
