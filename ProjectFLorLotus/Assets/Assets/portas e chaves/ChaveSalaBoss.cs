using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveSalaBoss : MonoBehaviour
{
    public GameObject key;
    public GameObject porta1;
    public GameObject porta2;
    [SerializeField] private GameObject messageKey;
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
        if (collisioninfo.gameObject.CompareTag("Player"))
        {
            messageKey.SetActive(true);
            Invoke("DisableKeyMessage", 1.5f);
            key.SetActive(false);
            Destroy(key,2);
            Destroy(porta1);
            Destroy(porta2);
        }   
    }
    void DisableKeyMessage()
    {
        messageKey.SetActive(false);
    }


}
