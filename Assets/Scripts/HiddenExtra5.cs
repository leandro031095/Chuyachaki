using UnityEngine;
using UnityEngine.UI;

public class HiddenExtra5 : MonoBehaviour, IInteractable
{
    Inventory inventory;
    void Start()
    {
        if (Saved.extra.extraTexts[5])
        {
            Destroy(gameObject);
        }
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void Interact(DisplayImage currentDisplay)
    {
        
            if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == "Stairs")
            {
                inventory.currentSelectedSlot.gameObject.GetComponent<Slot>().Use();
                Saved.extra.extraTexts[5] = true;
                DisplayText.TextToDisplay(SavedL.language.ExtraText_5);
                Destroy(gameObject);
            }
        
    }
}