using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [HideInInspector]
    public AnimationClip duration;

    public Animator fade;

    private void Awake()
    {
        duration = Resources.Load<AnimationClip>("AnimationClip/Duration");
    }

    public IEnumerator ChangeSceneIntro(string scene, float multiplier)
    {
        yield return new WaitForSeconds(duration.length * multiplier);
        fade.SetBool("Change", true);
        yield return new WaitForSeconds(duration.length);
        SceneManager.LoadSceneAsync(scene);
    }

    public IEnumerator ChangeScene(string scene)
    {
        fade.SetBool("Change", true);
        yield return new WaitForSeconds(duration.length);
        SceneManager.LoadSceneAsync(scene);
    }


}
