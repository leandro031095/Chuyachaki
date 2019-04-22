using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoTecho : MonoBehaviour
{
    private void Update()
    {
        Vector3 vector = this.GetComponent<Transform>().position;
        RaycastHit2D hitI = Physics2D.Raycast(vector, new Vector2(-1,-1));
        RaycastHit2D hitD = Physics2D.Raycast(vector, new Vector2(1, -1));
        if (hitI || hitD )
        {
            Debug.Log("yes");
        }
        //if (this.GetComponent<Transform>().rotation.x > 0.6f && this.GetComponent<Transform>().rotation.x < 0.68f)
        //{
        //    Debug.Log("direccion correcta");
        //}
    }
}
