using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    private static RectTransform rectPosition;

    private void Start()
    {
        rectPosition = GetComponent<RectTransform>();
        GetComponentInParent<MobileObject>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Finish")
        {
            print("Lo lograstes");
        }
        else
        {
            Destroy(gameObject);
            transform.GetComponentInParent<ObjectListener>().destroyed = true;
        }
    }

    //public static void Movement()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Vector2 position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
    //        rectPosition.position = new Vector3(position.x, position.y, 0);
    //    }
    //}
}
