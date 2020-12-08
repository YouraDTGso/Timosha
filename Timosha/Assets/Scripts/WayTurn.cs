/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class WayTurn : MonoBehaviour
{    
    Check_tag check_Tag;
    Spawn_of_beam_right spawn_Of_Beam_Right;
    Cube_Control cube_Control;


    public GameObject trackPointPrefab;
    GameObject trackPoint;
    public GameObject pointsPrefab;
    public List<GameObject> trackPoints = new List<GameObject>(11);

    public bool SamTriggerIs;
    bool FirstPoint = false;

    public void Start()
    {
        check_Tag = GameObject.Find("beams in void").GetComponent<Check_tag>();
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
        SamTriggerIs = false;
    }

    public void Update()
    {
        if (SamTriggerIs == true && check_Tag.beams[check_Tag.beams.Count - 1].tag != "tag3")
        {
            TrackOfBeam();
            //cube_Control.moveInWay = true;
        }        
    }

    public void TrackOfBeam()
    {
        if (check_Tag.beams[check_Tag.beams.Count - 1].tag != "tag2")
        {
            trackPointPrefab.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(check_Tag.beams[check_Tag.beams.Count - 1].tag != "tag1")
        {
            trackPointPrefab.transform.localScale = new Vector3(1, 1, 1);
        }

        trackPoint = Instantiate(trackPointPrefab, check_Tag.beams[check_Tag.beams.Count - 1].transform);
        trackPoint.transform.localPosition = new Vector3(transform.position.x, 0.91f, 7);
        for (int i = 0; i < 11; i++)
        {
            //if (FirstPoint==false)
            //{
            //    trackPoints.Add(Instantiate(pointsPrefab, trackPoint.transform));
            //    Transform trackPointsPos = transform;
            //    trackPointsPos.transform.localPosition = Vector3.zero;
            //    trackPoints[trackPoints.Count - 1].transform.localPosition = trackPointsPos.transform.localPosition;
            //    FirstPoint = true;
            //}
            //else 
            //{                
            //}

            trackPoints.Add(Instantiate(pointsPrefab, trackPoint.transform));//was in "else" block
            //trackPoints[trackPoints.Count - 1].transform.localPosition = trackPoints[0].transform.localPosition;
        }
        trackPoints[0].transform.localPosition = new Vector3(0, 0, -1.75f);
        trackPoints[1].transform.localPosition = new Vector3(0, 0, -1.4f);
        trackPoints[2].transform.localPosition = new Vector3(0, 0, -1.05f);
        trackPoints[3].transform.localPosition = new Vector3(0, 0, -0.7f);

        trackPoints[4].transform.localPosition = new Vector3(0, 0, -0.35f);
        trackPoints[5].transform.localPosition = new Vector3(0, 0, 0);
        trackPoints[6].transform.localPosition = new Vector3(0.03f, 0, 0.35f);
        trackPoints[7].transform.localPosition = new Vector3(0.09f, 0, 0.7f);

        trackPoints[8].transform.localPosition = new Vector3(0.17f, 0, 1.05f);
        trackPoints[9].transform.localPosition = new Vector3(0.33f, 0, 1.4f);
        trackPoints[10].transform.localPosition = new Vector3(0.55f, 0, 1.75f);
        
        //trackPoints[11].transform.localPosition = new Vector3(0.09f, 0, 0.7f);
        //trackPoints[12].transform.localPosition = new Vector3(0.17f, 0, 1.05f);
        //trackPoints[13].transform.localPosition = new Vector3(0.33f, 0, 1.4f);
        //trackPoints[14].transform.localPosition = new Vector3(0.55f, 0, 1.75f);


        SamTriggerIs = false;
    }
}
*/