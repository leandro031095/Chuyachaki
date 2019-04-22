using UnityEngine;

public class CameraDragger : MonoBehaviour
{

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;
    bool isZooming;
    public GameObject currentDisplay;

    void Update()
    {
        NewDragMethod();
    }
    void NewDragMethod()
    {
        if (currentDisplay.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
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
                        gameObject.transform.Translate(-PositionDifference);
                        gameObject.transform.position = new Vector2(Mathf.Clamp(gameObject.transform.position.x, -490, 490), Mathf.Clamp(gameObject.transform.position.y, -190, 190));
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
                        camera_GameObject.GetComponent<Camera>().orthographicSize += (PositionDifference.magnitude);

                    if (Vector2.Distance(DragNewPosition, Finger0Position) >= DistanceBetweenFingers)
                        camera_GameObject.GetComponent<Camera>().orthographicSize -= (PositionDifference.magnitude);

                    DistanceBetweenFingers = Vector2.Distance(DragNewPosition, Finger0Position);
                }
                DragStartPosition = GetWorldPositionOfFinger(1);
                Finger0Position = GetWorldPositionOfFinger(0);
            }*/
        }
    }

    Vector2 GetWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    /*Vector2 GetWorldPositionOfFinger(int FingerIndex)
    {
        return camera_GameObject.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(FingerIndex).position);
    }*/
}
