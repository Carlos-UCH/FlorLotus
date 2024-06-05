using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField]
    private Item[] items;

    private bool isOpen = false;

    private void DropItems()
    {
        foreach (Item item in items)
        {
            //Create New Item
            GameObject itemToDrop = new GameObject(item.itemName);
            Item newItem = itemToDrop.AddComponent<Item>();
            newItem.quantity = 1;
            newItem.itemName = item.itemName;
            newItem.sprite = item.sprite;
            newItem.itemDescription = item.itemDescription;

            // Create and modify the SR
            SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
            sr.sprite = item.sprite;
            sr.sortingOrder = 10;

            //Add a Collider
            itemToDrop.AddComponent<BoxCollider2D>();

            //Set the Location
            itemToDrop.transform.position = this.transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
            itemToDrop.transform.localScale = new Vector3(7, 7, 7);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isOpen)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (Input.GetKey(KeyCode.C))
                {
                    DropItems();
                    isOpen = true;
                }
            }
        }
    }
}