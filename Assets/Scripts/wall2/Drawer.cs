using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{

    public bool open;


    public void Interact(DisplayImage currentDisplay)
    {
        //gameObject.GetComponent<AudioSource>().Play();
        if (open)
        {
            gameObject.transform.parent.Find("DrawerOpened").gameObject.SetActive(true);
            gameObject.transform.parent.Find("DrawerOpened").gameObject.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            
            //GameObject.Find("DrawerOpened").SetActive(true);
        }
        else
        {

            if (!HammerIsPicked())
            {
                GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Inventory Items/Hammer"));
                combinedItem.GetComponent<PickUpItem>().ItemPickUp();
            }
            //GameObject.Find("Drawer").SetActive(true);
            //GameObject.Find("DrawerOpened").SetActive(false);
            gameObject.transform.parent.Find("Drawer").gameObject.SetActive(true);
            gameObject.transform.parent.Find("Drawer").gameObject.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
    bool HammerIsPicked()
    {
        bool used = false;
        foreach (PickedItems item in Saved.player.PickedItems)
        {
            if (item.DisplaySprite == "Hammer")
            {
                used = true;
            }
        }
        return used;
    }
}
