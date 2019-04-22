using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health = 1;
    public bool puzzleComplete = false;
    public bool safeComplete = false;

    public List<PickedItems> PickedItems = new List<PickedItems>();
    public bool typewriterComplete = false;
    public bool brokenMirror = false;
    public bool mural = false;
    public bool bookcase = false;
    public int bookPieces = 0;
    public int pills = 10;

    //public bool[] extraTexts = new bool[6];
    public int[] puzzlePieces = new int [9] { 0,2,4,3,1,5,6,7,8};
    public int wall = 1;
    public bool lastKeyPicked = false;

    public bool nightmare1triggered = false;
}