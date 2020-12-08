using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Check_tag : MonoBehaviour
{
    #region VARIABLES
    public GameObject beams_right;
    public GameObject beams_left;
    public GameObject beams_down;
    public GameObject beams_prefab_main;

    public GameObject pointPrefabForBezier;
    protected internal Transform pointFromSam;
    protected internal Transform pointFromBeam;
    protected internal Transform pointAngleFromBeam;
    protected internal Transform pointAngleFromSam;

    internal bool FirstBeamRorLwas;

    public List<GameObject> beams = new List<GameObject>();
    public float random_value;//random choice of position of new prefab
    #endregion
    public void Awake()
    {
        AddFirstBeam();
        AddFirstBeam();
        AddFirstBeam();
        //AddFirstPointsOfBezier();
        beams_right.transform.tag = "tag1";
        beams_left.transform.tag = "tag2";
        beams_down.transform.tag = "tag3";

        FirstBeamRorLwas = false;

    }

    public void Update()
    {
        random_value = Random.Range(1, 4);
        random_value = Mathf.Floor(random_value);  
    }

    #region SPAWN TEST
    //public void OnTriggerEnter(Collider other)
    //{
    //    //if (other.tag == "sam_trigger"&&)
    //    if (other.tag == "sam_trigger")
    //    { 
    //        //Debug.Log(random_value);
    //        if (random_value == 1)
    //            AddBeamRight();
    //        if (random_value == 2)
    //            AddBeamLeft();
    //        if (random_value == 3)
    //            AddBeamDown();
    //    }
    //}
    #endregion

    #region FIRSTBEAMFUNCTION
    public void AddFirstBeam()
    {
        if (beams.Count==0)
        {
            Quaternion newBeamRot = transform.rotation;
            newBeamRot = Quaternion.Euler(0, 0, 0);
            beams.Add(Instantiate(beams_prefab_main));
            Transform new_pos = transform;
            new_pos.transform.localPosition = new Vector3(0, -0.41f, +34.48f);
            beams[beams.Count-1].transform.position = new_pos.transform.position;
            beams[beams.Count - 1].transform.SetParent(null);
        }
        else if (beams.Count>=1)
        {
            Quaternion newBeamRot = beams_prefab_main.transform.rotation;
            newBeamRot = Quaternion.Euler(0, 0, 0);
            beams.Add(Instantiate(beams_prefab_main, beams[beams.Count - 1].transform));
            Transform new_pos = beams[beams.Count - 1].transform;
            new_pos.transform.localPosition = new Vector3(0, 0, -17.24f);
            beams[beams.Count-1].transform.position = new_pos.transform.position;
            beams[beams.Count - 1].transform.SetParent(null);
        }
    }
    #endregion
    public void AddBeamRight()
    {
        Vector3 newBeamRot = transform.rotation.eulerAngles;
        newBeamRot = new Vector3(0, 90, 0);
        beams_right.transform.rotation = Quaternion.Euler(newBeamRot);
        beams.Add(Instantiate(beams_right, beams[beams.Count - 1].transform));//question to parent
        
        //setup the position relatively of parent
        Transform newBeamPos = beams[beams.Count - 1].transform;
        newBeamPos.transform.localPosition = new Vector3(-14, 0, -8.3f);
        beams[beams.Count-1].transform.position = newBeamPos.transform.position;
        beams[beams.Count - 1].transform.SetParent(null);

        //points for bezier

        //pointFromBeam = Instantiate(pointPrefabForBezier, beams[beams.Count - 1].transform).GetComponent<Transform>();
        //pointFromBeam.localPosition = new Vector3(0, 0.91f, 7);
        
        //pointAngleFromBeam = Instantiate(pointPrefabForBezier, beams[beams.Count - 1].transform).GetComponent<Transform>();
        //pointAngleFromBeam.localPosition = new Vector3(0, 0.91f, 8.5f);

        FirstBeamRorLwas = true;
    }

    public void AddBeamLeft()
    {
        Vector3 newBeamRot = transform.rotation.eulerAngles;
        newBeamRot = new Vector3(0, -90, 0);
        beams_left.transform.rotation = Quaternion.Euler(newBeamRot);
        beams.Add(Instantiate(beams_left, beams[beams.Count - 1].transform));//question to parent

        //setup the position relatively of parent
        Transform newBeamPos = beams[beams.Count - 1].transform;
        newBeamPos.transform.localPosition = new Vector3(+14, 0, -8.3f);
        beams[beams.Count-1].transform.position = newBeamPos.transform.position;
        beams[beams.Count - 1].transform.SetParent(null);

        //points for bezier 

        //pointFromBeam = Instantiate(pointPrefabForBezier, beams[beams.Count - 1].transform).GetComponent<Transform>();
        //pointFromBeam.localPosition = new Vector3(0, 0.91f, 7);
        
        //pointAngleFromBeam = Instantiate(pointPrefabForBezier, beams[beams.Count - 1].transform).GetComponent<Transform>();
        //pointAngleFromBeam.localPosition = new Vector3(0, 0.91f, 8.5f);

        FirstBeamRorLwas = true;
    }

    public void AddBeamDown()
    {
        Vector3 newBeamRot = transform.rotation.eulerAngles;
        newBeamRot = new Vector3(0, 0, 0);
        beams_down.transform.rotation = Quaternion.Euler(newBeamRot);
        beams.Add(Instantiate(beams_down, beams[beams.Count - 1].transform));//question to parent

        //setup the position relatively of parent
        Transform newBeamPos = beams[beams.Count - 1].transform;
        newBeamPos.transform.localPosition = new Vector3(0, -5, -17.24f);
        beams[beams.Count-1].transform.position = newBeamPos.transform.position;
        beams[beams.Count - 1].transform.SetParent(null);
    }

    public void AddFirstPointsOfBezier()
    {
        //points for bezier

        pointFromBeam = Instantiate(pointPrefabForBezier, beams[beams.Count - 1].transform).GetComponent<Transform>();
        pointFromBeam.localPosition = new Vector3(0, 0.91f, 7);

        pointAngleFromBeam = Instantiate(pointPrefabForBezier, beams[beams.Count - 1].transform).GetComponent<Transform>();
        pointAngleFromBeam.localPosition = new Vector3(0, 0.91f, 8.5f);
    }
}
