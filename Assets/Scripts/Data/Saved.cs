using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Saved : MonoBehaviour
{
    private const string Key = "Data";
    [HideInInspector]
    public static string path;
    [HideInInspector]
    public static string json;
    [HideInInspector]
    public static SettingsData settings;
    [HideInInspector]
    public static TriggersData triggers;
    [HideInInspector]
    public static PlayerData player;
    [HideInInspector]
    public static ExtraData extra;

    private void Awake()
    {
        settings = Fill<SettingsData>(new SettingsData());
        triggers = Fill<TriggersData>(new TriggersData());
        player = Fill<PlayerData>(new PlayerData());
        extra = Fill<ExtraData>(new ExtraData());
    }

    private void OnDestroy()
    {
        SaveAll();
    }

    private void OnApplicationQuit()
    {
        SaveAll();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveAll();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveAll();
        }
    }

    private static void SaveAll()
    {
        Save<SettingsData>(settings);
        Save<TriggersData>(triggers);
        Save<PlayerData>(player);
        Save<ExtraData>(extra);
    }


    public static T Fill<T>(T data)
    {
        string s = data.GetType().Name + ".json";
        path = Path.Combine(Application.persistentDataPath, data.GetType().Name + ".json");
        json = JsonUtility.ToJson(data,true);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<T>(json);
            return data;
        }
        else
        {
            Save<T>(data);
            return data;
        }

    }

    public static void Save<T>(T data)
    {
        string s = data.GetType().Name + ".json";
        path = Path.Combine(Application.persistentDataPath, data.GetType().Name + ".json");
        json = JsonUtility.ToJson(data,true);
        File.WriteAllText(path, json);
    }
}