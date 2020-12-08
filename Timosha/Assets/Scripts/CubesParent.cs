using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesParent : MonoBehaviour
{
    Cube_Control cube_Control;
    Animator camera_here;

    int[] anglesTrargets = new int[5] { 180, 270, 0, 360, 90 };
    int playerTurnPosition;
    int playerHeight;
    
    public float speed = 6;

    //bool startTurnFunc = false;
    int q = 1;
    Quaternion originRotation;

    void Start()
    {        
        camera_here = GameObject.Find("Main Camera").GetComponent<Animator>();
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
        //playerTurnPosition = (int)transform.eulerAngles.y;
        //playerHeight = (int)transform.eulerAngles.x;
        originRotation = transform.rotation;
    }


    void FixedUpdate()
    {
        if (camera_here.GetBool("cb") == false)
        {
            transform.Translate(Vector3.forward * 0 * Time.fixedDeltaTime);
        }

        else if (camera_here.GetBool("cb") == true)
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);

            //save anlge of player before turn
            if (cube_Control.button_was_rights == false && cube_Control.button_was_lefts == false)
            {
                playerTurnPosition = (int)transform.eulerAngles.y;                
            }
            if (cube_Control.button_was_up == false && cube_Control.button_was_down == false)
            {
                playerHeight = (int)transform.eulerAngles.x;
            }

            if ((cube_Control.button_was_rights == true && cube_Control.button_was_lefts == false)
                && (cube_Control.button_was_up == false && cube_Control.button_was_down == false))
            {
                turn_of_right();
            }

            else if ((cube_Control.button_was_rights == false && cube_Control.button_was_lefts == true)
                && (cube_Control.button_was_up == false && cube_Control.button_was_down == false))
            {
                turn_of_left();
            }

            if ((cube_Control.button_was_up == true && cube_Control.button_was_down == false)
                && (cube_Control.button_was_rights == false && cube_Control.button_was_lefts == false))
            {
                turn_to_up();
            }

            else if ((cube_Control.button_was_down == true && cube_Control.button_was_up == false)
                && (cube_Control.button_was_rights == false && cube_Control.button_was_lefts == false))
            {
                turn_to_down();
            }
        }
    }
    // UP and DOWN

    void turn_to_up()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, -Vector3.right);
        transform.rotation = originRotation * rotY;
        q++;
        if (q == 26)
        {
            originRotation = transform.rotation;
            cube_Control.button_was_up = false;
            q = 0;
        }
    }

    void turn_to_down()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, Vector3.right);
        transform.rotation = originRotation * rotY;
        q++;
        if (q == 26)
        {
            originRotation = transform.rotation;
            cube_Control.button_was_down = false;
            q = 0;
        }
    }



    //turn to right
    public void turn_of_right()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, Vector3.up);
        transform.rotation = originRotation * rotY;
        q++;
        if (q == 91)
        {
            originRotation = transform.rotation;
            cube_Control.button_was_rights = false;
            q = 0;
        }
    }
    //turn to left
    public void turn_of_left()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, -Vector3.up);
        transform.rotation = originRotation * rotY;
        q++;
        if (q == 91)
        {
            originRotation = transform.rotation;
            cube_Control.button_was_lefts = false;
            q = 0;
        }
    }
}
