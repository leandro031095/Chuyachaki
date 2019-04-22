using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void PlaySound(string SoundName)
    {
        gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/SoundEfects/" + SoundName);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
