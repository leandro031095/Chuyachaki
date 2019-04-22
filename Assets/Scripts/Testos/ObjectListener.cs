using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListener : MonoBehaviour
{
    private Vector3 initialPosition;

    public GameObject prefab;
    [HideInInspector]
    public bool destroyed = false;
    

    private void Start()
    {
        initialPosition = transform.position;
        Instantiate(prefab, new Vector3(-6.39f, -2.53f, transform.position.z), transform.rotation, transform);
    }

    void Update()
    {
        Clone();
    }

    public void Clone()
    {
        if (destroyed)
        {
            Instantiate(prefab, new Vector3(-6.39f,-2.53f,transform.position.z), transform.rotation,transform);
            GetComponent<MobileObject>().respawn = false;
            transform.position = initialPosition;
            destroyed = false;
        }
    }
}
