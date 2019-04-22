using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BotonBehaviour : MonoBehaviour
{
   public void OnClick()
    {
        Saved.Save(new TriggersData());
        Saved.triggers = Saved.Fill(new TriggersData());
        print(Saved.triggers.newgame.ToString());
        Saved.triggers.newgame = false;
    }
}
