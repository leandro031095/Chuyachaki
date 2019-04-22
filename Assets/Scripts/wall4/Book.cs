using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Book : MonoBehaviour
{

    public GameObject poemText;
    // Start is called before the first frame update
    void Start()
    {
        poemText.GetComponent<TextMeshProUGUI>().text = SavedL.language.BookText;
        FillBook();
        CheckIfCompleted();
    }

    void FillBook()
    {
        foreach (PickedItems item in Saved.player.PickedItems)
        {
            if ((item.DisplaySprite == "Circle" || item.DisplaySprite == "Triangle" || item.DisplaySprite == "Cube") && item.intProperty == 2)
            {
                GameObject.Find(item.DisplaySprite).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Inventory Items/" + item.DisplaySprite);
            }
        }
    }
    public void CheckIfCompleted()
    {
        if (Saved.player.bookPieces == 3)
        {
            gameObject.transform.Find("BookTab").gameObject.SetActive(true);
        }
    }

}
