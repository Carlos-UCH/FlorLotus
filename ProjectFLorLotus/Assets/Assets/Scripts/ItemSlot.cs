using System.Collections;
using System.Collections.Generic;
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
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    
    [SerializeField]
    private int maxNumberOfItems;

    
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

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //Check if Inv Full

        if (isFull){
            return quantity;
        }
        //update Name
        this.itemName = itemName;

        

        //update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //update Description
        this.itemDescription = itemDescription;

        //update quantity
        this.quantity += quantity;

        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
        

        //Retorno dos q N Foram
        int extraItems = this.quantity - maxNumberOfItems;
        this.quantity = maxNumberOfItems;
        return extraItems;
}   
    
        //Att Quantity TXT
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;

      


    }


    public void OnPointerClick(PointerEventData eventData)
    {

        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();

        }
        
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();

        }
    }

    public void OnLeftClick()
    {

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

    private void  EmptySlot()
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
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1,0,0);
        itemToDrop.transform.localScale = new Vector3 (7,7,7);

        this.quantity -= 1;
        quantityText.text = this.quantity.ToString();
        if (this.quantity <= 0)
        {
            EmptySlot();
        }

    }


}