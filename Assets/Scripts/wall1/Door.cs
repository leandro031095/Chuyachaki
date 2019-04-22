using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour, IInteractable
{
    public string Unlockitem;
    public GameObject ending;
    Inventory inventory;
    public GameObject doll;
    int i = 0;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == Unlockitem)
        {
            inventory.currentSelectedSlot.gameObject.GetComponent<Slot>().Use();
            doll.GetComponent<Doll>().DeactivateDoll();
            ending.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name + i));
            if (true) gameObject.GetComponent<AudioSource>().Play();
            i++;
            if (i == 3)
            {
                i = 0;
            }
        }
    }
}
