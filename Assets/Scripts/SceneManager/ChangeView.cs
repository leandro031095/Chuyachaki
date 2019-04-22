using UnityEngine;

public class ChangeView : MonoBehaviour, IInteractable
{
    public string SpriteName;
    public int zoom;
    

    public void Interact(DisplayImage currentDisplay)
    {
        currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.currentWall + "/" + SpriteName);
        if (zoom == 0)
        {
            currentDisplay.CurrentState = DisplayImage.State.changedView;

            GameObject.Find("PlayerCanvas").transform.Find("ButtonRight").gameObject.SetActive(false);
            GameObject.Find("PlayerCanvas").transform.Find("ButtonLeft").gameObject.SetActive(false);
            GameObject.Find("PlayerCanvas").transform.Find("ButtonReturn").gameObject.SetActive(true);

            GameObject.Find("Masks").SetActive(false);
            GameObject.Find("MaskBackground").SetActive(false);
        }
        else if (zoom == 1)
        {
            currentDisplay.CurrentState = DisplayImage.State.changedView1;
        }
        currentDisplay.changeCamera();
        currentDisplay.previousSprite = gameObject.transform.parent.name;
        
    }


}
