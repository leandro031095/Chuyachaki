using UnityEngine;

public class ExtraText : MonoBehaviour, IInteractable
{
    int number;
    void Start()
    {
        number = int.Parse(gameObject.name.Substring(10, 1));
        
        if (Saved.extra.extraTexts[number])
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (number != 0)
        {
            if (!CheckIfIsAvailable())
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //gameObject.SetActive(true);
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }


    public void Interact(DisplayImage currentDisplay)
    {
        if (CheckIfIsAvailable())
        {
            Saved.extra.extraTexts[number] = true;
            DisplayText.TextToDisplay(SavedL.language.GetParameter(gameObject.name));
            Destroy(gameObject);
        }
    }
    bool CheckIfIsAvailable()
    {
        if (number != 0)
        {
            if (Saved.extra.extraTexts[number - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}
