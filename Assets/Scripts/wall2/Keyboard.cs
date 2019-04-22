using UnityEngine;

public class Keyboard : MonoBehaviour
{
    string password = "";
    void Start()
    {
        //PlaceKeys();
        if (Saved.player.typewriterComplete) gameObject.transform.Find("TypewriterHole").gameObject.SetActive(true);
    }

    public void pressKeys(string character)
    {
        if (Saved.player.typewriterComplete) return;
        
        password = password + character;
        if (password.Length == 5)
        {
            password = password.Substring(1);
            Debug.Log(password);
            if (password == "jamu")
            {
                Saved.player.typewriterComplete = true;
                gameObject.transform.Find("TypewriterHole").gameObject.SetActive(true);
                DisplayText.TextToDisplay(SavedL.language.w2_TypewriterComplete);
            }
        }
    }

    void PlaceKeys()
    {
        foreach (PickedItems item in Saved.player.PickedItems)
        {
            if ((item.DisplaySprite == "J-Key" || item.DisplaySprite == "A-Key" || item.DisplaySprite == "M-Key" || item.DisplaySprite == "U-Key") && item.intProperty == 2)
            {
                GameObject.Find(item.DisplaySprite.ToLower().Substring(0, 1)).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Inventory Items/" + item.DisplaySprite);
            }
        }
    }
}
