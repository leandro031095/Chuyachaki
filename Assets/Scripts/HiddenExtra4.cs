using UnityEngine;

public class HiddenExtra4 : MonoBehaviour, IInteractable
{
    int counter;


    void Start()
    {


        if (Saved.extra.extraTexts[4])
        {
            Destroy(gameObject);
        }
        counter = 0;
    }
    public void Interact(DisplayImage currentDisplay)
    {
        counter++;
        if (counter == 3)
        {
            Saved.extra.extraTexts[4] = true;
            DisplayText.TextToDisplay(SavedL.language.ExtraText_4);
            Destroy(gameObject);
        }


    }
}
