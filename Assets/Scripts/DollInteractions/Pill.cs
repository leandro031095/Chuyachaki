using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pill : MonoBehaviour, IInteractable
{
    public float hp;
    DesperationBar hpBar;
    Text PillText;
    void Start()
    {
        PillText = GameObject.Find("PillText").GetComponent<Text>();
        hpBar = GameObject.Find("HealthBar").GetComponent<DesperationBar>();
        PillText.text = ""+Saved.player.pills;
    }
    IEnumerator HealthBar(float hp)
    {
        int i = 0;
        while (i < 30)
        {
            hpBar.ChangeHealth(hp / 30);
            i++;
            yield return new WaitForSeconds(0.0025f);
        }
    }

    public void Interact(DisplayImage currentDisplay)
    {
        //StartCoroutine(HealthBar(hp));
        Heal();
    }
    public void Heal()
    {
        if (Saved.player.pills != 0 && hpBar.healthSlider.value !=1)
        {
            StartCoroutine(HealthBar(hp));
            Saved.player.pills--;
            PillText.text = "" + Saved.player.pills;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void HealAmount(float n)
    {
        StartCoroutine(HealthBar(n));
    }
}
