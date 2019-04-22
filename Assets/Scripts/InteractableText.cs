using UnityEngine;

public class InteractableText : MonoBehaviour, IInteractable
{
    public bool sound;
    public void Interact(DisplayImage currentDisplay)
    {

        DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name));
        if (sound) gameObject.GetComponent<AudioSource>().Play();
    }
}
