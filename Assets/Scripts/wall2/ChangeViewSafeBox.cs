using UnityEngine;

public class ChangeViewSafeBox : MonoBehaviour, IInteractable
{
    public void Interact(DisplayImage currentDisplay)
    {
        currentDisplay.CurrentState = DisplayImage.State.changedView;
       
        
        if (Saved.player.safeComplete)
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall2/SafeBoxOpened");
        }
        else
        {
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall2/SafeBoxView");
        }
        currentDisplay.changeCamera();
        currentDisplay.previousSprite = gameObject.transform.parent.name;

        GameObject.Find("PlayerCanvas").transform.Find("ButtonRight").gameObject.SetActive(false);
        GameObject.Find("PlayerCanvas").transform.Find("ButtonLeft").gameObject.SetActive(false);
        GameObject.Find("PlayerCanvas").transform.Find("ButtonReturn").gameObject.SetActive(true);
        GameObject.Find("Masks").SetActive(false);
        GameObject.Find("MaskBackground").SetActive(false);
    }
}
