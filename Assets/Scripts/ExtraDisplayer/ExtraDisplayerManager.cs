using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExtraDisplayerManager : MonoBehaviour
{
    public TextMeshProUGUI extraText;
    public GameObject marcaDeAgua;

    private void Start()
    {
        if (Saved.triggers.extraCounter == 10)
        {
            extraText.text = SavedL.language.Credits;
            extraText.rectTransform.localPosition = new Vector3(0, 140, 0);
        }else
        if (Saved.triggers.extraCounter == 4)
        {
            extraText.text = SavedL.language.GetParameter("ExtraTextDescription_" + Saved.triggers.extraCounter);
            marcaDeAgua.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Extras/Extra" + Saved.triggers.extraCounter);
            extraText.rectTransform.localPosition = new Vector3(0, 140, 0);
        }
        else
        {
            extraText.text = SavedL.language.GetParameter("ExtraTextDescription_" + Saved.triggers.extraCounter);
            marcaDeAgua.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Extras/Extra" + Saved.triggers.extraCounter);
            extraText.rectTransform.localPosition = new Vector3(0, 0, 0);
        }
        
        /*switch (Saved.triggers.extraCounter)
        {
            case 0:
                extraText.text = SavedL.language.ExtraText_0;
                //marcaDeAgua.GetComponent<Image>().sprite = Agrega la imagen de lo que se toco!
                break;

            case 1:
                extraText.text = SavedL.language.ExtraText_1;
                //marcaDeAgua.GetComponent<Image>().sprite = Agrega la imagen de lo que se toco!
                break;
        }*/
    }


}
