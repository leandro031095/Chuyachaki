using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPiece : MonoBehaviour, IInteractable
{
    public string Unlockitem;

    private Inventory inventory;
    private Book book;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        book = GameObject.Find("BookView").GetComponent<Book>();
        //showImage();
    }
    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == Unlockitem)
        {
            inventory.currentSelectedSlot.gameObject.GetComponent<Slot>().Use();
            GameObject.Find(Unlockitem).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Inventory Items/" + Unlockitem);

            Saved.player.bookPieces++;
            book.CheckIfCompleted();
        }
    }
    /*void showImage()
    {
        //int PlacedPieces = 0;
        foreach(PickedItems item in Saved.player.PickedItems)
        {
            if (item.DisplaySprite == Unlockitem && item.intProperty == 2)
            {
                GameObject.Find(Unlockitem).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Inventory Items/" + Unlockitem);
                Saved.player.PlacedPeaces++;
            }
        }
        if (Saved.player.PlacedPeaces == 3)
        {
            GameObject.Find("BookTab").SetActive(true);
        }
    }*/
    
}
