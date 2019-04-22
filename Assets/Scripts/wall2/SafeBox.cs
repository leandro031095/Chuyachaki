using UnityEngine;

public class SafeBox : MonoBehaviour
{
    //DisplayImage currentDisplay;

    void Start()
    {
        if (Saved.player.safeComplete)
        {
            /*currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall2/SafeBoxOpened");*/
            //gameObject.transform.Find("Container").gameObject.SetActive(true);
            //gameObject.transform.Find("Manija").gameObject.SetActive(false);
        }
    }
}
