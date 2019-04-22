using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject slots;
    public GameObject itemDisplayer { get; private set; }

    private GameObject InventorySlots;

    void Start()
    {
        slots = GameObject.Find("Slots");
        itemDisplayer = GameObject.Find("ItemDisplayer");
        itemDisplayer.SetActive(false);
        SortInventoryItems();
        InventoryPosition();
        currentSelectedSlot = GameObject.Find("slot");
        previousSelectedSlot = currentSelectedSlot;
        SelectSlot();
    }

    public void SortInventoryItems()
    {
        cleanInventory();
        if (Saved.player.PickedItems.Count > 0)
        {
            InventorySlots = GameObject.Find("Slots");
            foreach (PickedItems pickedItem in Saved.player.PickedItems)
            {
                if (pickedItem.intProperty != 2)
                {
                    foreach (Transform slot in InventorySlots.transform)
                    {
                        if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
                        {
                            slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/" + pickedItem.DisplaySprite);
                            slot.GetComponent<Slot>().AssignProperty(pickedItem.intProperty, pickedItem.DisplaySprite, pickedItem.DisplayImage, pickedItem.CombinationItem);
                            break;
                        }
                    }
                }
            }
        }
    }
    void cleanInventory()
    {
        foreach (Transform slot in slots.transform)
        {
            slot.GetComponent<Slot>().ClearSlot();
        }
    }
    
    void InventoryPosition()
    {
        RectTransform inventory = gameObject.GetComponent<RectTransform>();
        if (Saved.settings.leftHand)
        {
            inventory.localPosition = new Vector3(-inventory.localPosition.x, inventory.localPosition.y, inventory.localPosition.z);
        }
        else
        {
            inventory.localPosition = new Vector3(inventory.localPosition.x, inventory.localPosition.y, inventory.localPosition.z);
        }
    }
    public void SelectSlot()
    {
        foreach (Transform slot in slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot /*&& slot.GetComponent<Slot>().ItemProperty == Slot.property.usable*/)
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            //else if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.displayable)
            //{
                //slot.GetComponent<Slot>().DisplayItem();
            //}
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 0.2784314f);
            }
        }
    }
    void HideDisplay()
    {
        if (Input.GetMouseButtonDown(0) 
            && (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0) 
            || !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)))
        {
            itemDisplayer.SetActive(false);
            if(currentSelectedSlot.GetComponent<Slot>().ItemProperty == Slot.property.displayable )
            {
                currentSelectedSlot = previousSelectedSlot;
                previousSelectedSlot = currentSelectedSlot;
            }
        }
    }
}