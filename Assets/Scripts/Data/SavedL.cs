using System.Collections.Generic;
using UnityEngine;

public class SavedL : MonoBehaviour
{
    public List<TextAsset> Language;
    [HideInInspector]
    public static Language language;

    void Awake()
    {
        foreach (TextAsset l in Language)
        {
            var english = Language[0];
            if (Application.systemLanguage.ToString() == l.name)
            {
                language = JsonUtility.FromJson<Language>(l.text);
                break;
            }
            else
            {
                language = JsonUtility.FromJson<Language>(english.text);
            }
        }
    }

}
