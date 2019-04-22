
using UnityEngine;

public class LastKey : MonoBehaviour,IInteractable
{
    public GameObject KeySprite;
    


    public void Interact(DisplayImage currentDisplay)
    {
        KeySprite.SetActive(false);
    }
}
