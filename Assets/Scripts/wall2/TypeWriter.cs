using UnityEngine;

public class TypeWriter : MonoBehaviour
{
    bool twShow = true;
    bool keyShow = true;
    public GameObject HoleSprite;

    void Start()
    {
        if (twShow && Saved.player.typewriterComplete)
        {
            //gameObject.transform.Find("TypewriterHoleSprite").gameObject.SetActive(true);
            HoleSprite.SetActive(true);
            twShow = false;
        }
        /*if (Saved.player.PickedItems.Count > 0)
        {
            foreach (PickedItems item in Saved.player.PickedItems)
            {
                if (item.DisplaySprite == "Key_Exit")
                {
                    HoleSprite.transform.Find("KeySprite").gameObject.SetActive(false);

                    //Destroy(gameObject);
                }
            }
        }*/
        if (keyShow && Saved.player.lastKeyPicked)
        {
            HoleSprite.transform.Find("KeySprite").gameObject.SetActive(false);
            keyShow = false;
        }
    }
    void Update()
    {
        if (twShow && Saved.player.typewriterComplete )
        {
            //gameObject.transform.Find("TypewriterHoleSprite").gameObject.SetActive(true);
            HoleSprite.SetActive(true);
            twShow = false;
        }
        if (keyShow && Saved.player.lastKeyPicked)
        {
            HoleSprite.transform.Find("KeySprite").gameObject.SetActive(false);
            keyShow = false;
        }
    }
}
   
