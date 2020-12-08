/*    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_turns : MonoBehaviour
{
    Sam_Control functions;
    Quaternion originRot;
    public Transform Sam;
    //float angle = 90;
    public bool button_was_right;
    public bool button_was_left;
    public bool button_was_down;
    int q = 1;    

    public void Start()
    {
        functions = GetComponent<Sam_Control>();
        originRot = transform.rotation;
        button_was_right = false;
        button_was_left = false;
    }

    public void FixedUpdate()
    {
        if (button_was_right == true && button_was_left == false)
        {
            turnRight();
        }
        if (button_was_left == true && button_was_right == false)
        {
            turnLeft();
        }
    }

    public void turnRight()
    {
        button_was_right = true;
        Quaternion rotY = Quaternion.AngleAxis(q, Vector3.up);
        transform.rotation = originRot * rotY;
        q++;
        if (q == 91)
        {
            originRot = transform.rotation;
            button_was_right = false;
            q = 0;
        }
    }

    public void turnLeft()
    {
        button_was_left = true;
        Quaternion rotY = Quaternion.AngleAxis(q, -Vector3.up);
        transform.rotation = originRot * rotY;
        q++;
        if (q == 91)
        {
            originRot = transform.rotation;
            button_was_left = false;
            q = 0;
        }
    }
}
*/