using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterKey : MonoBehaviour, IInteractable
{
    public string UnlockItem ;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void Interact(DisplayImage currentDisplay)
    {
        
        if (gameObject.name == "x")
        {
            GameObject.Find("TypewriterSound").GetComponent<AudioSource>().Play();
            GameObject.Find("KeyboardView").GetComponent<Keyboard>().pressKeys(gameObject.name);
        }
        else
        {
            LoadSprite();
            if (gameObject.GetComponent<SpriteRenderer>().sprite.name == UnlockItem)
            {
                GameObject.Find("TypewriterSound").GetComponent<AudioSource>().Play();
                GameObject.Find("KeyboardView").GetComponent<Keyboard>().pressKeys(gameObject.name);
            }
        }
        
    }
    //CheckIfKeyIsPlaced
    void LoadSprite()
    {
        string unlockItem = /*GameObject.Find(UnlockItem.ToLower().Substring(0, 1)).GetComponent<TypewriterKey>().*/UnlockItem;

        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == unlockItem)
        {
            inventory.currentSelectedSlot.gameObject.GetComponent<Slot>().Use();
            GameObject.Find(UnlockItem.ToLower().Substring(0, 1)).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Inventory Items/" + unlockItem);
        }
    }
    void OnEnable()
    {
        foreach (PickedItems item in Saved.player.PickedItems)
        {
            if (UnlockItem == item.DisplaySprite && item.intProperty == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Inventory Items/" + item.DisplaySprite);
            }
        }
    }
}
