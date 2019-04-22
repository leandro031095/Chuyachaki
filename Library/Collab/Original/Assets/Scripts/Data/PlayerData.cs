using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health = 1;
    public bool puzzleComplete = false;

    public List<PickedItems> PickedItems = new List<PickedItems>();
    public bool typewriterComplete = false;
    public bool brokenMirror = false;
    public bool mural = false;
    public bool bookcase = false;
}