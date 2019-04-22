using UnityEngine;

public class Magazines : MonoBehaviour,IInteractable
{
    int i = 0;
    public void Interact(DisplayImage currentDisplay)
    {
        DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name + i));
        i++;
        if (i == 3)
        {
            i = 0;
        }
    }
}
