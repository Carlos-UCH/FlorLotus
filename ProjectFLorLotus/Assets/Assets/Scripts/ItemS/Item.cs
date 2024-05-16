
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public int quantity;

    public Sprite sprite;

    [TextArea]
    public string itemDescription;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.C))
            {
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
    }
}