using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCenter : MonoBehaviour
{
    Cube_Control cube_Control;
    Check_tag check_Tag;
    BezierTurn bezierTurn;

    public void Awake()
    {
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
        check_Tag = GameObject.Find("beams in void").GetComponent<Check_tag>();
        bezierTurn = GameObject.Find("Way_of_turn").GetComponent<BezierTurn>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="sam_trigger")
        {
            //cube_Control.transform.LookAt(null);

            //cube_Control.moveOutWay = false;
            //cube_Control.OnCenter = true;
            //cube_Control.tParam = 0;
            Destroy(bezierTurn.bezierInBeam[bezierTurn.bezierInBeam.Count - 1] as GameObject);
            bezierTurn.bezierInBeam.RemoveAt(0);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "sam_trigger")
        {
            //cube_Control.moveOutWay = false;
            //cube_Control.OnCenter = false;
        }
    }
}
