using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language 
{
    //Menu
    public string Exit;
    public string Start;
    public string Settings;
    public string Continue;
    public string NewGame;

    //Settings
    public string Back;
    public string Mute;
    public string LeftHanded;
    public string LeftHandedExp;
    public string InvertedAxis;

    //Prelude
    public string Skip;
    public string Begin;
    public string PreludeText;
    public string SkipTutorial;

    //Extra Feature
    public string IntroScene;

    //GameScene
    public string Resume;
    public string PlayStore;

    //GameOver
    public string GameOver;
    public string Menu;

    //Tutorial
    public string Tutorial1;
    public string Tutorial2;

    //Interactables Texts
    public string w1_Picture1;
    public string w1_Picture2;
    public string w1_Switch;
    public string w1_Door0;
    public string w1_Door1;
    public string w1_Door2;
    public string w1_Letter;

    public string Mural0;
    public string Mural1;
    public string Mural2;
    public string w2_Bookcase;
    public string w2_Papers;
    public string w2_Desk;
    public string w2_TypewriterComplete;

    public string w3_DreamCatcher;
    public string w3_Dresses;
    public string w3_Magazines0;
    public string w3_Magazines1;
    public string w3_Magazines2;
    public string w3_Mirror0;
    public string w3_Mirror1;

    public string w4_MotherStuff;
    public string w4_FatherStuff;
    public string w4_Toys;

    //Extra Texts
    public string ExtraText_0;
    public string ExtraText_1;
    public string ExtraText_2;
    public string ExtraText_3;
    public string ExtraText_4;
    public string ExtraText_5;

    public string ExtraTextDescription_0;
    public string ExtraTextDescription_1;
    public string ExtraTextDescription_2;
    public string ExtraTextDescription_3;
    public string ExtraTextDescription_4;
    public string ExtraTextDescription_5;

    public string PickedItem;
    public string NighmareText0;
    public string NighmareText1;
    public string NighmareText2;

    public string Credits;
    public string BookText;

    public string GetParameter(string id)
    {
        string word = (string)this.GetType().GetField(id).GetValue(this);
        return word;
    }
}
