using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect effect;
    public string itemName;

    public int quantity;

    public Sprite sprite;

    [TextArea]
    public string itemDescription;

    [SerializeField] private InventoryManager inventoryManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        effect.Apply(collision.gameObject);

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
}
