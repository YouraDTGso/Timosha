using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikeTarget : MonoBehaviour
{
    public static bool WasClickOnTarget;
    public static int indexOfEnemy;
    public static Vector3 currentTarget;


    void Start()
    {
        WasClickOnTarget = false;
    }


    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //WasClickOnTarget = true;
        //currentTarget = this.transform.position;
    }
}
