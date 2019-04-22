using UnityEngine;

public class Mural : MonoBehaviour, IInteractable
{
    int i = 0;
    public void Interact(DisplayImage currentDisplay)
    {
        DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name + i));
        i++;
        if (i == 3)
        {
            i = 0;
            if (!Saved.player.mural)
            {
                GetComponent<Animator>().SetBool("Active", true);
                Saved.player.mural = true;
            }
        }
    }
}
