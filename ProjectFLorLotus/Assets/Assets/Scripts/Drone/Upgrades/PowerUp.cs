using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect effect;
    public string itemName;

    public int quantity;

    public Sprite sprite;
    [SerializeField] private GameObject messageUpgrade;


    [TextArea]
    public string itemDescription;

    [SerializeField] private InventoryManager inventoryManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player")){
        Destroy(gameObject,2);
        gameObject.SetActive(false);
        effect.Apply(collision.gameObject);
        messageUpgrade.SetActive(true);
        Invoke("DisableUpgradeMessage",1.5f);
        }


        int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
        if (leftOverItems <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            quantity = leftOverItems;
        }
     
       }
    
    void DisableUpgradeMessage()
    {
        messageUpgrade.SetActive(false);
    }
}
