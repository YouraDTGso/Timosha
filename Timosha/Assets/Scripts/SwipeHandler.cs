using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Cube_Control cube_Control;
    CheckOtherTags checkOtherTags;
    BezierStaticForBeams bezierStaticForBeams;

    public bool SamInTrigger;

    public void Awake()
    {
        cube_Control = GameObject.Find("Cube").GetComponent<Cube_Control>();

        SamInTrigger = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y) && cube_Control.playButtonWas==true)
        {
            if (eventData.delta.x < 0 && cube_Control.button_was_rights == false)
            {
                cube_Control.button_was_lefts = true;
            }

            else if (eventData.delta.x > 0 && cube_Control.button_was_lefts == false)
            {
                cube_Control.button_was_rights = true;               
            }
        }
        else if (Mathf.Abs(eventData.delta.x) < Mathf.Abs(eventData.delta.y) && cube_Control.playButtonWas == true)
        {
            if (eventData.delta.y < 0 )
            {
                //if (cube_Control.button_was_up == false)
                //{
                //    cube_Control.button_was_down = true;
                //}
                Debug.Log("down");
            }
            else 
            {
                //if (cube_Control.button_was_down == false)
                //{
                //    cube_Control.button_was_up = true;
                //}                    
                Debug.Log("up");
            }            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
