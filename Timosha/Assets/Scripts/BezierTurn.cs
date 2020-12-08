using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BezierTurn : MonoBehaviour
{
    Cube_Control cube_Control;
    Check_tag check_Tag;
    SwipeHandler swipeHandler;
    [SerializeField]
    protected internal GameObject bezierPrefab;
    [SerializeField]
    protected internal List<GameObject> bezierInBeam = new List<GameObject>();

    internal void Start()
    {
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();
        check_Tag = GameObject.Find("beams in void").GetComponent<Check_tag>();
        swipeHandler = GameObject.Find("SwipeScript").GetComponent<SwipeHandler>();
    }

    internal void Update()
    {

    }

    internal void AddBezierInRightBeam()
    {
        bezierPrefab.transform.rotation = Quaternion.Euler(0, -90, 0);
        bezierPrefab.transform.localScale = new Vector3(1, 1, -1);
        bezierInBeam.Add(Instantiate(bezierPrefab, check_Tag.beams[check_Tag.beams.Count - 1].transform));
        bezierInBeam[bezierInBeam.Count - 1].transform.localPosition = new Vector3(-2, 0.41f, 7);
        //bezierInBeam[bezierInBeam.Count - 1].rotation=Quaternion.Euler(0, -90, 0);
    }
    internal void AddBezierInLeftBeam()
    {
        bezierPrefab.transform.rotation = Quaternion.Euler(0, -90, 0);
        bezierPrefab.transform.localScale = new Vector3(1, 1, 1);
        bezierInBeam.Add(Instantiate(bezierPrefab, check_Tag.beams[check_Tag.beams.Count - 1].transform));
        bezierInBeam[bezierInBeam.Count - 1].transform.localPosition = new Vector3(2, 0.41f, 7);
        //bezierInBeam[bezierInBeam.Count - 1].rotation = Quaternion.Euler(0, -90, 0);
    }


}
