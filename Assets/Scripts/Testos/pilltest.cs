using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pilltest : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Me estas tocando");
    }
}
