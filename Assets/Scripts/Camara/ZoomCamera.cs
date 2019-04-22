using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondaryCamera;
    public float cameraVelocity;


    private Vector2 initalPosition;
    private float directionX;
    private float directionY;
    private int invertedAxis;

    private void Start()
    {
        InvertedAxis();
    }

    void Update()
    {
        //Movement();
        NewDragMethod();
    }

    private void Movement()
    {
        if (Input.touchCount > 0)
        {
            //Saved.triggers.touching = true;
            HorizontalLimit();
            VerticalLimit();
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    initalPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    directionX = touch.position.x - initalPosition.x;
                    directionY = touch.position.y - initalPosition.y;

                    StartCoroutine(XAxisMovement());
                    StartCoroutine(YaxisMovement());
                    break;

                case TouchPhase.Ended:
                    StopAllCoroutines();
                    break;
            }
        }
        //Saved.triggers.touching ++;
    }


    IEnumerator  YaxisMovement()
    {
        if (directionY > 0)
        {
            secondaryCamera.GetComponent<Transform>().position +=
                new Vector3(0, invertedAxis * (directionY / cameraVelocity), 0);
        }
        if (directionY < 0)
        {
            secondaryCamera.GetComponent<Transform>().position -=
                new Vector3(0, invertedAxis * (Math.Abs(directionY) / cameraVelocity), 0);
        }
        yield return null;
    }

    IEnumerator  XAxisMovement()
    {
        if (directionX > 0)
        {
            secondaryCamera.GetComponent<Transform>().position +=
                new Vector3(invertedAxis * (directionX / cameraVelocity), 0, 0);
        }
        if (directionX < 0)
        {
            secondaryCamera.GetComponent<Transform>().position -=
                new Vector3(invertedAxis * (Math.Abs(directionX) / cameraVelocity), 0, 0);
        }
        yield return null;
    }




    //private void YaxisMovement()
    //{
    //    if (directionY > 0)
    //    {
    //        secondaryCamera.GetComponent<Transform>().position +=
    //            new Vector3(0, invertedAxis * (directionY / cameraVelocity), 0);
    //    }
    //    if (directionY < 0)
    //    {
    //        secondaryCamera.GetComponent<Transform>().position -=
    //            new Vector3(0, invertedAxis * (Math.Abs(directionY) / cameraVelocity), 0);
    //    }
    //}

    //private void XAxisMovement()
    //{
    //    if (directionX > 0)
    //    {
    //        secondaryCamera.GetComponent<Transform>().position +=
    //            new Vector3(invertedAxis * (directionX / cameraVelocity), 0, 0);
    //    }
    //    if (directionX < 0)
    //    {
    //        secondaryCamera.GetComponent<Transform>().position -=
    //            new Vector3(invertedAxis * (Math.Abs(directionX) / cameraVelocity), 0, 0);
    //    }
    //}

    public void HorizontalLimit()
    {

        if (secondaryCamera.GetComponent<Transform>().position.x > Screen.currentResolution.width/4)
        {
            secondaryCamera.GetComponent<Transform>().position = mainCamera.GetComponent<Transform>().position;
        }
        else if (secondaryCamera.GetComponent<Transform>().position.x < -Screen.currentResolution.width/4)
        {
            secondaryCamera.GetComponent<Transform>().position = mainCamera.GetComponent<Transform>().position;
        }

    }

    public void VerticalLimit()
    {

        if (secondaryCamera.GetComponent<Transform>().position.y > Screen.currentResolution.height / 4)
        {
            secondaryCamera.GetComponent<Transform>().position = mainCamera.GetComponent<Transform>().position;
        }
        else if (secondaryCamera.GetComponent<Transform>().position.y < -Screen.currentResolution.height / 4)
        {
            secondaryCamera.GetComponent<Transform>().position = mainCamera.GetComponent<Transform>().position;
        }
    }

    private void InvertedAxis()
    {
        if (Saved.settings.invertedAxis)
        {
            invertedAxis = 1;
        }
        else
        {
            invertedAxis = -1;
        }
    }








    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;
    bool isZooming;


  
    // giving a try this new drag
    void NewDragMethod()
    {
        if (Input.touchCount == 0 && isZooming)
        {
            isZooming = false;
        }

        if (Input.touchCount == 1)
        {
            if (!isZooming)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 NewPosition = GetWorldPosition();
                    Vector2 PositionDifference = NewPosition - StartPosition;
                    secondaryCamera.transform.Translate(-PositionDifference);
                }
                StartPosition = GetWorldPosition();
            }
        }
        /*else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                isZooming = true;

                DragNewPosition = GetWorldPositionOfFinger(1);
                Vector2 PositionDifference = DragNewPosition - DragStartPosition;

                if (Vector2.Distance(DragNewPosition, Finger0Position) < DistanceBetweenFingers)
                    mainCamera.GetComponent<Camera>().orthographicSize += (PositionDifference.magnitude);

                if (Vector2.Distance(DragNewPosition, Finger0Position) >= DistanceBetweenFingers)
                    mainCamera.GetComponent<Camera>().orthographicSize -= (PositionDifference.magnitude);

                DistanceBetweenFingers = Vector2.Distance(DragNewPosition, Finger0Position);
            }
            DragStartPosition = GetWorldPositionOfFinger(1);
            Finger0Position = GetWorldPositionOfFinger(0);
        }*/
    }

    Vector2 GetWorldPosition()
    {
        return mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetWorldPositionOfFinger(int FingerIndex)
    {
        return mainCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(FingerIndex).position);
    }
}