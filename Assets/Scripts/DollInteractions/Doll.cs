using UnityEngine;

public class Doll : MonoBehaviour
{
    DesperationBar hpBar;
    public Camera zommCamera;
    public float dollDamage;
    DisplayImage displayImage;
    int tries = 0;
    public GameObject SoundManager;
    bool FirstSight = true;
    bool DollSpawned = false;



    void Start()
    {
        hpBar = GameObject.Find("HealthBar").GetComponent<DesperationBar>();
        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void DollDamage()
    {
        float distance = Vector2.Distance(gameObject.transform.position, zommCamera.transform.position);
        float damage = dollDamage * 10 / distance;

        if (Saved.triggers.nightmare)
        {
            hpBar.ChangeHealth(-0.0015f);
            hpBar.ShakeBar();
            if (FirstSight)
            {
                FirstSight = false;
                SoundManager.GetComponent<SoundManager>().PlaySound("Breathing");
            }
        }
        else if (distance < 228)
        {
            hpBar.ChangeHealth(-damage);
            hpBar.ShakeBar();
            if (FirstSight)
            {
                SoundManager.GetComponent<SoundManager>().PlaySound("Breathing");
                FirstSight = false;
            }
        }
        else
        {
            hpBar.ChangeHealth(-0.00025f);
            FirstSight = true;
        }
    }
    public void DeactivateDoll()
    {
        CancelInvoke("DollDamage");
        CancelInvoke("DollRunning");
        CancelInvoke("DollSpawn");
        DollSpawned = false;
        gameObject.SetActive(false);
    }
    public void DollRunning()
    {
        SoundManager.GetComponent<SoundManager>().PlaySound("Running");
    }
    public void ActivateDoll()
    {
        int RunningDelay = Random.Range(1, 5);
        Invoke("DollRunning", RunningDelay);
        int SpawnDelay = Random.Range(5, 10);
        Invoke("DollSpawn", SpawnDelay);
    }
   
    public void Pause()
    {
        if (DollSpawned)
        {
            CancelInvoke("DollDamage");
        }
        else
        {
            //CancelInvoke("DollRunning");
            CancelInvoke("DollSpawn");
        }
    }
    public void UnPause()
    {
        if (DollSpawned)
        {
            InvokeRepeating("DollDamage", 0.2f, 0.025f);
        }
        else
        {
            int RunningDelay = Random.Range(1, 2);
            Invoke("DollRunning", RunningDelay);
            int SpawnDelay = Random.Range(2, 5);
            Invoke("DollSpawn", SpawnDelay);
        }
    }

    

    public void DollSpawn()
    {

        //Just in case doll does not deactive in time
        if (displayImage.CurrentState == DisplayImage.State.changedView || displayImage.CurrentState == DisplayImage.State.changedView1)
        {
            return;
        }

        if (Saved.triggers.nightmare)
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Material/Wave");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("Material/Opaque");
        }
        DollPosition();
        gameObject.SetActive(true);
        InvokeRepeating("DollDamage", 2.0f, 0.05f);
    }
   
    void DollPosition()
    {
        float[,] position = new float[7, 3];
        int[] sprite = new int[11];
        if (displayImage.currentWall == 1)
        {
            //derecha abajo, agarrado del papel, foco1, foco2, mesa
            position = new float[5, 3] { { 480, -180, 500 }, { 412.2f, 107.5f, 500 }, { 32, 293, 500 }, { -11, 276.2f, 500 }, { -494.7f, -33.7f, 500 } };
            sprite = new int[] { 11, 12, 13, 21, 22, 31, 41, 51, 52, 53, 54 };
        }
        else if (displayImage.currentWall == 2)
        {
            position = new float[7, 3] { { 209.9f, 67.1f,500 }, { 264.6f, 237.2f,500 }, { 264.6f, 221.8f,500 }, { 265.4f, 281.7f,500 },
                { -480, 25,500 }, { -117, -278,500 }, { -117, -261,500 } };
            sprite = new int[] { 11, 12, 21, 31, 41, 51, 52, 61, 71 };
        }
        else if (displayImage.currentWall == 3)
        {
            position = new float[6, 3] { { 591, -93, 500 }, { 571, -19, 500 }, { 94, -151, 500 }, { 41.5f, -214.5f, 500 }, { -544.3f, -177.7f, 500 }, { -574.5f, -172.7f, 500 } };
            sprite = new int[] { 11, 21, 31, 41, 51, 61 };
        }
        else if (displayImage.currentWall == 4)
        {
            position = new float[5, 3] { { -302.9f, 298.8f, 500 }, { -328.7f, 319.1f, 500 }, { 315, 48, 500 }, { -360, -193, 500 }, { 428.6f, -157.2f, 500 } };
            sprite = new int[] { 11, 21, 31, 41, 51 };
        }
        int i = Random.Range(0, sprite.Length);

        int randomDoll = int.Parse(sprite[i].ToString().Substring(0, 1)) - 1;
        gameObject.transform.position = new Vector3(position[randomDoll, 0], position[randomDoll, 1], position[randomDoll, 2]);

        float distance = Vector2.Distance(gameObject.transform.position, zommCamera.transform.position);
        tries++;
        //counting tries just to avoid an infinite loop

        if ((distance < 228 && tries < 10 )|| (Saved.triggers.nightmare && displayImage.currentWall == 4 && sprite[i] == 31))
        {
            DollPosition();
        }
        else
        {
            tries = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + displayImage.currentWall + "/Dolls/" + sprite[i]);
            DollSpawned = true;
        }
    }


    void LaughPitch()
    {
        float hp = hpBar.healthSlider.value;
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        if (hp > 0.75 && hp <= 1)
        {
            sound.pitch = 1;
        }
        else if (hp > 0.5 && hp < 0.75)
        {
            sound.pitch = 0.9f;
        }
        else if (hp > 0.25 && hp <= 0.5)
        {
            sound.pitch = 0.8f;
        }
        else if (hp <= 0.25)
        {
            sound.pitch = 0.7f;
        }
    }
}
