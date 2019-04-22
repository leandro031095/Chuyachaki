using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class PickUpItem : MonoBehaviour, IInteractable
{
    //public int idItem;
    public string DisplaySprite;
    public string DisplayImage;
    public string CombinationItem;
    public enum property { usable, displayable };
    public property itemProperty;

    private Inventory inventory;

    private PickedItems PickedItems = new PickedItems();

    void Start()
    {
        DestroyPickedObjects();
    }
    void DestroyPickedObjects()
    {
        if(Saved.player.PickedItems.Count > 0)
        {
            foreach (PickedItems item in Saved.player.PickedItems)
            {
                if (DisplaySprite == item.DisplaySprite)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }
    
    public void ItemPickUp()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        PickedItems.SaveItem(DisplaySprite, DisplayImage, CombinationItem, (int)itemProperty);
        inventory.SortInventoryItems();
        GameObject.Find("ItemSound").GetComponent<AudioSource>().Play();
        //DisplayText.TextToDisplay(SavedL.language.PickedItem);

        if (DisplaySprite == "Key_Exit") Saved.player.lastKeyPicked = true;
        Destroy(gameObject);

    }
}
