using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class DisplayImage : MonoBehaviour
{
    public GameObject NightmareManager;
    Vector3 position;
    

    public enum State { normal,zoom, changedView, changedView1 };
    [HideInInspector]
    public string previousSprite;
    public  State CurrentState { get; set; }
    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == 5)
                currentWall = 1;
            else if (value == 0)
                currentWall = 4;
            else
                currentWall = value;
        }
    }
    Doll doll;
    private ObjectsManage objectsManage;

    public CinemachineVirtualCamera ZoomCamera;
    public CinemachineVirtualCamera NormalCamera;
    public GameObject MainCamera;
    
    public void changeCamera()
    {
        if (CurrentState == State.changedView)
        {
            /*ZoomCamera.m_Lens.OrthographicSize = 384;
            position = ZoomCamera.transform.position;
            ZoomCamera.transform.position = new Vector3(0, 0, 0);*/
            doll.DeactivateDoll();
            //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + CurrentWall);
            //CurrentState = State.normal;
            Camera.main.orthographicSize = 384;
            position = MainCamera.transform.position;
            MainCamera.transform.position = new Vector3(0, 0, 0);

        }
        else if (CurrentState == State.changedView1)
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + CurrentWall + "/" + previousSprite);
            //CurrentState = State.changedView;
        }
        else if(CurrentState == State.normal)
        {
            /*ZoomCamera.m_Lens.OrthographicSize = 192;
            ZoomCamera.transform.position = position;*/

            
            MainCamera.GetComponent<Camera>().orthographicSize = 192;
            MainCamera.transform.position = position;
            doll.ActivateDoll();
        }
        objectsManage.ManageObjects();
        if (Saved.triggers.nightmare && CurrentState == State.normal)
        {
            Saved.triggers.level = "easy";
            NightmareManager.SetActive(true);
            
        }
    }
    

    public int currentWall;
    private int previousWall;

    void Start()
    {
        doll = GameObject.Find("doll").GetComponent<Doll>();
        Saved.triggers.prelude = true;
        previousWall = 0;
        currentWall = Saved.player.wall;

        objectsManage = GameObject.Find("sceneManager").GetComponent<ObjectsManage>();
        //ChangeWall();

        //LoadSavedWall();

        if (Saved.triggers.nightmare && CurrentState == State.normal)
        {
            Saved.triggers.level = "easy";
            NightmareManager.SetActive(true);
            
        }
    }

    // debo hacer que esta funcion se llame en el onClick
    void Update()
    {
        if (currentWall != previousWall)
        {
            ChangeWall();
        }
    }

    public void ChangeWall()
    {
        
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        objectsManage.ManageObjects();
        doll.DeactivateDoll();
        doll.ActivateDoll();


        previousWall = currentWall;
    }
}
