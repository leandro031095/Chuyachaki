using UnityEngine;
using UnityEngine.UI;

public class Mirror : MonoBehaviour,IInteractable
{
    public string Unlockitem;

    private Inventory inventory;
    void Start()
    {
        if (Saved.player.brokenMirror) BreakGlass();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void BreakGlass()
    {
        transform.Find("BrokenGlass").gameObject.SetActive(false);
        transform.Find("Hole").gameObject.SetActive(true);
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (!Saved.player.brokenMirror && inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == Unlockitem)
        {
            inventory.currentSelectedSlot.gameObject.GetComponent<Slot>().Use();
            BreakGlass();
            Saved.player.brokenMirror = true;
            gameObject.GetComponent<AudioSource>().Play();
            //DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name + 1));
        }else if (Saved.player.brokenMirror)
        {
            DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name + 1));
        }
        else
        {
            DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name + 0));
        }
    }
}
