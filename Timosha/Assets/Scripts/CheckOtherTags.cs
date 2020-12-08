using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOtherTags : MonoBehaviour
{
    SwipeHandler swipeHandler;
    Check_tag check_Tag;
    //WayTurn wayTurn;
    //Sam_Control sam_Control;
    Cube_Control cube_Control;
    BezierTurn bezierTurn;

    float random_value;
    public bool SamTrigger;
    

    public void Start()
    {
        //check_Tag1 = GetComponent<Check_tag>();
        check_Tag = GameObject.FindGameObjectWithTag("beam_pos_trigger").GetComponent<Check_tag>();
        //wayTurn = GameObject.Find("Way_of_turn").GetComponent<WayTurn>();
        //sam_Control = GameObject.Find("Sam").GetComponent<Sam_Control>();

        swipeHandler = GameObject.Find("SwipeScript").GetComponent<SwipeHandler>();
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
        bezierTurn = GameObject.Find("Way_of_turn").GetComponent<BezierTurn>();
        SamTrigger = false;        
    }

    public void Update()
    {
        random_value = Random.Range(1, 4);
        random_value = Mathf.Floor(random_value);
    }
    
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "sam_trigger")
        {
            //algorithm of correct spawn of beams

            if (random_value == 1)
            {
                if ((check_Tag.beams[check_Tag.beams.Count-1].tag != "tag1") && (check_Tag.beams[check_Tag.beams.Count - 2].tag != "tag1"))
                {                    
                    check_Tag.AddBeamRight();
                    bezierTurn.AddBezierInRightBeam();
                    //wayTurn.SamTriggerIs = true;
                    //sam_Control.moveInWay = true;
                    //cube_Control.moveInWay = true;
                }
                else if ((check_Tag.beams[check_Tag.beams.Count - 3].tag != "tag2"))
                {                    
                    check_Tag.AddBeamLeft();
                    bezierTurn.AddBezierInLeftBeam();
                    //wayTurn.SamTriggerIs = true;
                    //sam_Control.moveInWay = true;
                    //cube_Control.moveInWay = true;
                }
                else
                    check_Tag.AddBeamDown();
            }

            if (random_value == 2)
            {
                if ((check_Tag.beams[check_Tag.beams.Count-1].tag != "tag2") && (check_Tag.beams[check_Tag.beams.Count - 2].tag != "tag2"))
                {                     
                    check_Tag.AddBeamLeft();
                    bezierTurn.AddBezierInLeftBeam();
                    //wayTurn.SamTriggerIs = true;
                    //sam_Control.moveInWay = true;
                    //cube_Control.moveInWay = true;
                }
                else if ((check_Tag.beams[check_Tag.beams.Count - 3].tag != "tag1"))
                {                    
                    check_Tag.AddBeamRight();
                    bezierTurn.AddBezierInRightBeam();
                    //wayTurn.SamTriggerIs = true;
                    //sam_Control.moveInWay = true;
                    //cube_Control.moveInWay = true;
                }
                else
                    check_Tag.AddBeamDown();

            }

            if (random_value == 3)
            {
                if ((check_Tag.beams[check_Tag.beams.Count - 1].tag != "tag3") && (check_Tag.beams[check_Tag.beams.Count - 2].tag != "tag3"))
                {
                    check_Tag.AddBeamDown();
                }
                else if ((check_Tag.beams[check_Tag.beams.Count - 3].tag != "tag1"))
                {
                    check_Tag.AddBeamRight();
                    bezierTurn.AddBezierInRightBeam();
                    //wayTurn.SamTriggerIs = true;
                    //sam_Control.moveInWay = true;
                    //cube_Control.moveInWay = true;
                }
                else
                {
                    check_Tag.AddBeamLeft();
                    bezierTurn.AddBezierInLeftBeam();
                    //wayTurn.SamTriggerIs = true;
                    //sam_Control.moveInWay = true;
                    //cube_Control.moveInWay = true;
                }
                    
            }               
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "sam_trigger")
        {
            swipeHandler.SamInTrigger = true;
            //Debug.Log(swipeHandler.SamInTrigger);
            //Debug.Log("SamInTrigger!");            
        }        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "sam_trigger")
        {
            swipeHandler.SamInTrigger = false;
            //Debug.Log(swipeHandler.SamInTrigger);
            //Debug.Log("nothing!");
        }
    }
}
