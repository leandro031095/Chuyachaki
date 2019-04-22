using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manija : MonoBehaviour
{
    private const string Left = "Left";
    private const string Right = "Right";
    private Vector2 initialPosition;
    private Vector2 finalPosition;
    private Animator animator;

    private bool flagAnimationEnded;
    private SafePassword password;
    public AnimationClip duration;

    private void OnEnable()
    {
        flagAnimationEnded = false;
        transform.rotation = new Quaternion();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        password = GetComponent<SafePassword>();

        if (Saved.player.safeComplete)
        {
            GetComponent<Manija>().enabled = false;
        }
    }



    public void InitializeAnimation(string s)
    {
        if (!flagAnimationEnded)
        {
            if (s == "Right")
            {
                password.password += "r";
                StartCoroutine(Animation(s));
            }
            else
            {
                password.password += "l";
                StartCoroutine(Animation(s));
            }
        }
        
    }


    IEnumerator Animation(string s)
    {
        flagAnimationEnded = true;
        animator.SetBool(s, true);
        yield return null;
        animator.SetBool(s, false);
        yield return new WaitForSeconds(duration.length);
        transform.rotation.Set(0,0,0,0);
        password.CheckPassword();
        flagAnimationEnded = false;
        StopAllCoroutines();
    }
}
    //private void Recognize()
    //{
    //    Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
    //    if(hit.transform.name == "Manija")
    //    {
    //        flagInitialTouch = true;
    //    }
    //    else
    //    {
    //        flagInitialTouch = false;
    //    }
    //}
    
    //public void Direction()
    //{

    //    if(Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        switch (touch.phase)
    //        {
    //            case TouchPhase.Began:
    //                Recognize();
    //                initialPosition = touch.position;
    //                break;

    //            case TouchPhase.Moved:
    //                finalPosition = touch.position;
    //                break;

    //            case TouchPhase.Ended:
    //                if (flagInitialTouch && flagAnimationEnded)
    //                {
    //                    if (finalPosition.x - initialPosition.x < 0)
    //                    {
    //                        password.password += "l";
    //                        StartCoroutine(Animation(Left));
    //                        break;
    //                    }
    //                    else if (finalPosition.x - initialPosition.x > 0)
    //                    {

    //                        StartCoroutine(Animation(Right));
    //                        break;
    //                    }
    //                }
    //                break;
    //        }
    //    }
    //}

