using UnityEngine;
using System.Collections.Generic;
using System;


public class ZoomInObject : MonoBehaviour, IInteractable
{
    public float ZoomRatio = .5f;

    public void Interact(DisplayImage currentDisplay)
    {
        Camera.main.orthographicSize *= ZoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);
        gameObject.layer = 2;
        currentDisplay.CurrentState = DisplayImage.State.zoom;

        ConstraintCamera(); 
    }

    void ConstraintCamera()
    {
        var height = Camera.main.orthographicSize;
        var width = height * Camera.main.aspect;

        var cameraBounds = GameObject.Find("cameraBounds");



        var cameraX = Camera.main.transform.position.x;
        var cameraY = Camera.main.transform.position.y;
        var cameraBoundsX = cameraBounds.transform.position.x;
        var cameraBoundsY = cameraBounds.transform.position.y;
        var cameraBoundsBCX = cameraBounds.GetComponent<BoxCollider2D>().size.x / 2;//8
        var cameraBoundsBCY = cameraBounds.GetComponent<BoxCollider2D>().size.y / 2;//5


        if (cameraX + width > cameraBoundsX + cameraBoundsBCX)
        {
            Camera.main.transform.position += new Vector3(cameraBoundsX + cameraBoundsBCX - (cameraX + width), 0, 0);
        }
        if (cameraX - width < cameraBoundsX - cameraBoundsBCX)
        {
            Camera.main.transform.position += new Vector3(cameraBoundsX - cameraBoundsBCX - (cameraX - width), 0, 0);
        }
        if (cameraY + height > cameraBoundsY + cameraBoundsBCY)
        {
            Camera.main.transform.position += new Vector3(0,cameraBoundsY + cameraBoundsBCY - (cameraY + height), 0);
        }
        if (cameraY - height < cameraBoundsY - cameraBoundsBCY)
        {
            Camera.main.transform.position += new Vector3(0,cameraBoundsY - cameraBoundsBCY - (cameraY - height), 0);
        }
    }
}
