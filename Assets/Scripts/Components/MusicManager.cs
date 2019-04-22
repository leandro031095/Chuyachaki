using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private GameObject musicPlayer;
    private AudioClip audio;

    private void Start()
    {
        musicPlayer = GameObject.Find("MusicPlayer");
        CheckScene();
    }

    private void CheckScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu":
                audio = Resources.Load<AudioClip>("Musica/Menu Principal");
                musicPlayer.GetComponent<AudioSource>().clip = audio;
                break;
            case "GameScene":
                audio = Resources.Load<AudioClip>("Musica/Musica in game");
                musicPlayer.GetComponent<AudioSource>().clip = audio;
                break;
            case "GameOver":
                audio = Resources.Load<AudioClip>("Musica/Game Over");
                musicPlayer.GetComponent<AudioSource>().clip = audio;
                break;
        }
        musicPlayer.GetComponent<AudioSource>().Play();
        //musicPlayer.GetComponent<AudioSource>().pitch = 1;
    }
}
