using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Inventory inventory;
    public enum property {  usable, displayable, empty};
    public property ItemProperty { get; set; }
    public string displaySprite;
    public string displayImage;
    public string combinationItem { get; private set; }


    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.previousSelectedSlot = inventory.currentSelectedSlot;
        inventory.currentSelectedSlot = gameObject;
        inventory.SelectSlot();
        Combine();
        //if (ItemProperty == Slot.property.displayable) DisplayItem();
    }

    //Assign properties recovered by the PickUpItem script
    public void AssignProperty(int orderNumber, string displaySprite, string displayImage,string combinationItem)
    {
        this.ItemProperty = (property)orderNumber;
        this.displaySprite = displaySprite;
        this.displayImage = displayImage;
        this.combinationItem = combinationItem;
    }
    public void DisplayItem()
    {
        inventory.itemDisplayer.SetActive(true);
        inventory.itemDisplayer.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/"+ displayImage);
    }
    public void Use()
    {
        foreach (PickedItems item in Saved.player.PickedItems)
        {
            if (item.DisplaySprite == displaySprite)
            {
                item.intProperty = 2;
            }
        }
        inventory.SortInventoryItems();
        Saved.Save<PlayerData>(Saved.player);
    }
    void Combine()
    {
        if( combinationItem != ""
            && inventory.previousSelectedSlot.GetComponent<Slot>().combinationItem == combinationItem 
            && inventory.previousSelectedSlot.GetComponent<Slot>().displaySprite != displaySprite)
        {
            foreach (PickedItems item in Saved.player.PickedItems)
            {
                if (item.CombinationItem == gameObject.GetComponent<Slot>().combinationItem)
                {
                    item.intProperty = 2;
                }
            }
            GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/"+ combinationItem));
            combinedItem.GetComponent<PickUpItem>().ItemPickUp();
        }
    }
    public void ClearSlot()
    {
        ItemProperty = Slot.property.empty;
        displaySprite = "";
        displayImage = "";
        combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
    }
}
