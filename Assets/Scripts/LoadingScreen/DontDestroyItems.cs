using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DontDestroyItems : MonoBehaviour
{
    public List<GameObject> ObjectsToSave;
    //public VideoClip video;


    void Start()
    {
    
        Saved.triggers.extraFeatureBack = false;
        SaveObjects();
        VideoPlayer video = GameObject.Find("GoodSeedIntro").GetComponent<VideoPlayer>();
        StartCoroutine(GetComponent<FadeOut>().ChangeSceneIntro("Menu",(float)video.length));
        MuteToggle.ListenerVolume();
    }


    private void SaveObjects()
    {
        foreach(GameObject g in ObjectsToSave)
        {
            DontDestroyOnLoad(g);
        }
    }

}
