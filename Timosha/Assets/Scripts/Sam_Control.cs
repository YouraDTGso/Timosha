/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sam_Control : MonoBehaviour
{
    WayTurn wayTurn;
    Check_tag check_Tag;

    Animator camera_here;
    Animator Run_in_game;

    public float speed=7;
    //float del_delta = 10;
    //float delta_for_angle = 90;
    byte nextPointIndex = 5;

    public bool button_was_rights;
    public bool button_was_lefts;
    public bool moveInWay;
    public bool playButtonWas;

    Quaternion originRotation;
    int q = 1;
    
    
    void Awake()
    {
        wayTurn = GameObject.Find("Way_of_turn").GetComponent<WayTurn>();
        camera_here = GameObject.Find("Main Camera").GetComponent<Animator>();
        Check_tag check_Tag = GameObject.Find("beams in void").GetComponent<Check_tag>();

        Run_in_game = GameObject.Find("Sam").GetComponent<Animator>();
        button_was_rights = false;
        button_was_lefts = false;
        moveInWay = false;

        originRotation = transform.rotation;
        playButtonWas = false;
    }

    void Update()
    {
        if (camera_here.GetBool("cb") == true)
        {
            playButtonWas = true;            

            if (Input.GetKey(KeyCode.W))// temporary block of code
            {
                Run_in_game.SetFloat("Speed_in_three", 1.0f);
                //transform.Translate(-Vector3.forward * speed * Time.fixedDeltaTime);        

                if (moveInWay==true)
                {
                    StayOnWay();
                }
                else
                {
                    transform.Translate(-Vector3.forward * speed * Time.fixedDeltaTime);
                }
            }

            if (Input.GetKey(KeyCode.S))// temporary block of code
            {
                Run_in_game.SetFloat("Speed_in_three", 1.0f);
                transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
            }
            //Turns are worked by swipe
            if ((button_was_rights == true && button_was_lefts == false))
            {
                turn_of_right();
            }
            
            if ((button_was_lefts == true && button_was_rights == false))
            {
                turn_of_left();
            }
        }
    }

    public void turn_of_right()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, Vector3.up);
        transform.rotation = originRotation * rotY;
        q++;
        if (q == 91)
        {
            originRotation = transform.rotation;
            button_was_rights = false;
            q = 0;
        }
    }

    public void turn_of_left()
    {
        Quaternion rotY = Quaternion.AngleAxis(q, -Vector3.up);
        transform.rotation = originRotation*rotY;
        q++;
        if (q == 91)
        {
            originRotation = transform.rotation;
            button_was_lefts = false;
            q = 0;
        }     
    }

    public void StayOnWay()
    {
        moveInWay = true;

        if (Vector3.Distance(wayTurn.trackPoints[nextPointIndex].transform.position, transform.position) <= 0 && nextPointIndex!=0)
        {
            //Debug.Log(Vector3.Distance(wayTurn.trackPoints[nextPointIndex].transform.position, transform.position));
            nextPointIndex--;
        }
        if (nextPointIndex >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayTurn.trackPoints[nextPointIndex].transform.position, speed * Time.fixedDeltaTime);
            transform.LookAt(-1*wayTurn.trackPoints[nextPointIndex].transform.position);
        }
        if (nextPointIndex==0)
        {
            moveInWay = false;
            nextPointIndex = 5;
        }
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);
    }   
}
*/