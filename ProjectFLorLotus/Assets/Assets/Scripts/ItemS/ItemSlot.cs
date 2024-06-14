using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //======ITEM DATA ======//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public string itemDescription;
    public Sprite emptySprite;


    [SerializeField]
    private int maxNumberOfItems = 9;


    //======ITEM SLOT ======//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;

    //======ITEM DESCRIPTION SLOT ======//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantityToAdd, Sprite itemSprite, string itemDescription)
    {
        int remainingQuantity = 0;

        if (IsFull())
        {
            remainingQuantity = quantityToAdd;
        }
        else
        {
            this.itemName = itemName;
            this.itemSprite = itemSprite;
            this.itemImage.sprite = itemSprite;
            this.itemDescription = itemDescription;

            this.quantity += quantityToAdd;

            if (this.quantity > maxNumberOfItems)
            {
                this.quantity = maxNumberOfItems;
                remainingQuantity = quantityToAdd - maxNumberOfItems;
            }

            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
        }

        return remainingQuantity;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                OnLeftClick();
                break;
            case PointerEventData.InputButton.Right:
                OnRightClick();
                break;
        }
    }

    public void OnLeftClick()
    {
        if (thisItemSelected && itemName != "Buff de Velocidade" && itemName != "Buff de Vida" && itemName != "Buff de Energia" && itemName != "BombEx")
        {
            inventoryManager.UseItem(itemName);
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();

            if (this.quantity <= 0)
            {
                EmptySlot();
            }

        }

        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if (itemDescriptionImage.sprite == null)
        {
            itemDescriptionImage.sprite = emptySprite;
        }
    }
    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }



    public void OnRightClick()
    {
        //Create New Item
        if (itemName == "Buff de Velocidade" || itemName == "Buff de Vida" || itemName == "Buff de Energia" || itemName == "Neutralizador de Explosivos")
        {
            return;
        }
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.quantity = 1;
        newItem.itemName = itemName;
        newItem.sprite = itemSprite;
        newItem.itemDescription = itemDescription;

        // Create and modify the SR
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 10;

        //Add a Collider
        itemToDrop.AddComponent<BoxCollider2D>();

        //Set the Location
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1, 0, 0);
        itemToDrop.transform.localScale = new Vector3(7, 7, 7);

        this.quantity -= 1;
        quantityText.text = this.quantity.ToString();
        if (this.quantity <= 0)
        {
            EmptySlot();
        }
    }
    public bool IsFull()
    {
        return this.quantity >= this.maxNumberOfItems;
    }
}