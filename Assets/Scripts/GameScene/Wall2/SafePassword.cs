using UnityEngine;

public class SafePassword : MonoBehaviour
{
    public GameObject DisplayImage;
    public string password;

    public string passwordString;

    private char[] pchara;

    private void Start()
    {
        if (Saved.player.safeComplete)
        {
            GetComponent<SafePassword>().enabled = false;
        }
        pchara = passwordString.ToCharArray();
    }

    private void Update()
    {
        char[] chara = password.ToCharArray();

        if(password != "")
        {
            for(int i = 0; i < chara.Length; i++)
            {
                if (chara[i] != pchara[i])
                {
                    password = "";
                    break;
                }
            }
        }

    }

    public void CheckPassword()
    {
        if(password == passwordString)
        {
            Saved.triggers.nightmare = true;
            //Saved.triggers.level = "easy";
            Saved.player.safeComplete = true;
            //TODO Animacion para la puerta

            DisplayImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall2/SafeBoxOpened");
            DisplayImage.GetComponent<DisplayImage>().changeCamera();
            DisplayImage.GetComponent<DisplayImage>().previousSprite = gameObject.transform.parent.name;

            //gameObject.transform.parent.Find("Container").gameObject.SetActive(true);
            //Destroy(gameObject); //.SetActive(false);
        }

        //if(passwordLeft == turnLeft && passwordRight == turnRight)
        //{
        //    Debug.Log("Password Completed");
        //    GetComponent<Manija>().enabled = false;
        //    Saved.triggers.nightmare = true;
        //}
        //TODO password completado
    }
}
