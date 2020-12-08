using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    Animator camera_here;
    Cube_Control cube_Control;
    Vector3 offset;
    public GameObject target;

    public void Start()
    {
        camera_here = GameObject.Find("Main Camera").GetComponent<Animator>();        
        //target = GameObject.Find("Cube").GetComponent<Transform>();
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
        offset = transform.position - target.transform.position;
    }

    public void Update()
    {
        if (cube_Control.cameraOnPosition==true)
        {
            transform.SetParent(target.transform);
        }
    }
}
