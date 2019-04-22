using UnityEngine;
using UnityEngine.UI;

public class Bookcase : MonoBehaviour, IInteractable
{
    public string Unlockitem;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void Interact(DisplayImage currentDisplay)
    {
        if (!Saved.player.bookcase && inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == Unlockitem)
        {
            inventory.currentSelectedSlot.gameObject.GetComponent<Slot>().Use();
            Saved.player.bookcase = true;
            OpenBookcaseDoors();
        }
        else
        {
            if (!Saved.player.bookcase)
            {
                DisplayText.TextToDisplay(SavedL.language.GetParameter("w2_Bookcase"));
                gameObject.transform.parent.Find("LockedSound").GetComponent<AudioSource>().Play();
            }
            else
            {
                OpenBookcaseDoors();
            }
        }
    }

    void OpenBookcaseDoors()
    {
        switch (gameObject.name)
        {
            case "BookcaseDoor1":
                gameObject.SetActive(false);
                gameObject.transform.parent.Find("BookcaseDoor1Opened").gameObject.SetActive(true);
                break;
            case "BookcaseDoor2":
                gameObject.SetActive(false);
                gameObject.transform.parent.Find("BookcaseDoor2Opened").gameObject.SetActive(true);
                break;
            case "BookcaseDoor1Opened":
                gameObject.SetActive(false);
                gameObject.transform.parent.Find("BookcaseDoor1").gameObject.SetActive(true);
                break;
            case "BookcaseDoor2Opened":
                gameObject.SetActive(false);
                gameObject.transform.parent.Find("BookcaseDoor2").gameObject.SetActive(true);
                break;
        }
        gameObject.transform.parent.Find("OpenSound").GetComponent<AudioSource>().Play();
    }
}