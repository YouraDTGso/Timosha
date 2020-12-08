using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierStaticForBeams : MonoBehaviour
{
    Cube_Control cube_Control;
    Check_tag check_Tag;
    CheckOtherTags checkOtherTags;
    SwipeHandler swipeHandler;

    [SerializeField]
    protected internal Transform[] controlPoints;
    [SerializeField]
    protected internal Vector3 gizmosPosition;
    //internal bool CreateBezierSignal;
    

    public void Start()
    {
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
        check_Tag = GameObject.Find("beams in void").GetComponent<Check_tag>();
        checkOtherTags = GameObject.Find("main_beam(Clone)").GetComponent<Transform>().GetChild(0).GetComponent<CheckOtherTags>();
        swipeHandler = GameObject.Find("SwipeScript").GetComponent<SwipeHandler>();
        //CreateBezierSignal = false;
    }

    // Set position of points of Sam dependent on swipe
    internal void Update()
    {
        if (swipeHandler.SamInTrigger == true)// && (cube_Control.readyForBezierLeft == false || cube_Control.readyForBezierRight == false))
        {
            //Debug.Log("Tag of current beam: " + check_Tag.beams[check_Tag.beams.Count - 1].tag);
            //if (check_Tag.beams[check_Tag.beams.Count - 1].tag != "tag1")

            //if (cube_Control.readyForBezierRight)
            {
                if (check_Tag.beams[check_Tag.beams.Count - 1].tag == "tag1")
                {
                    StopMovingOfSamPoint();
                    //cube_Control.ForCoroutine = true;
                    //CreateBezierSignal = true;
                }
                else
                {
                    cube_Control.turn_of_right();
                }
            }

            //else if (cube_Control.readyForBezierLeft)
            {
                if (check_Tag.beams[check_Tag.beams.Count - 1].tag == "tag2")
                {
                    StopMovingOfSamPoint();
                    //cube_Control.ForCoroutine = true;
                    //CreateBezierSignal = true;
                }
                else
                {
                    cube_Control.turn_of_left();
                }    
            }
            //if (cube_Control.readyForBezierRight || cube_Control.readyForBezierLeft)
            //{
            //    StopMovingOfSamPoint();
            //    //cube_Control.readyForBezierLeft = false;
            //    //cube_Control.readyForBezierRight = false;
            //}
            //else if (true)
            {
                SetPointOfSamAsChild();
                //CreateBezierSignal = false;
            }
        }
        else
        {
            StopMovingOfSamPoint();
        }
    }

    internal void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.01f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                Mathf.Pow(t, 3) * controlPoints[3].position;
            Gizmos.DrawSphere(gizmosPosition, 0.03f);
        }

        Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z),
            new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));

        Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z),
            new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));
    }

    internal void SetPointOfSamAsChild()
    {
        controlPoints[0].SetParent(GameObject.Find("Cube").GetComponent<Transform>());
        controlPoints[0].localPosition = new Vector3(0, 0, 0);
        controlPoints[1].SetParent(GameObject.Find("Cube").GetComponent<Transform>());
        controlPoints[1].localPosition = new Vector3(0, 0, 1.5f);
    }
    internal void RightParentOfPoint()
    {
        controlPoints[0].SetParent(check_Tag.beams[check_Tag.beams.Count-1].transform.GetChild(2).transform);
        controlPoints[0].localPosition = new Vector3(-1.8f, 0, 0);
    }

    internal void LeftParentOfPoint()
    {
        controlPoints[0].SetParent(check_Tag.beams[check_Tag.beams.Count - 1].transform.GetChild(2).transform);
        controlPoints[0].localPosition = new Vector3(1.8f, 0, 0);
    }
    
    internal void StopMovingOfSamPoint()
    {
        //controlPoints[0].SetParent(check_Tag.beams[check_Tag.beams.Count - 1].transform.GetChild(3).transform);
        //controlPoints[0].localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        //controlPoints[0].SetParent(null);
        controlPoints[0].SetParent(check_Tag.beams[check_Tag.beams.Count - 1].transform.GetChild(2).transform);
        controlPoints[0].SetSiblingIndex(0);
        controlPoints[1].SetParent(check_Tag.beams[check_Tag.beams.Count - 1].transform.GetChild(2).transform);
        controlPoints[1].SetSiblingIndex(1);
        //cube_Control.readyForBezierRight = false;
        //cube_Control.readyForBezierLeft = false;
    }
}


