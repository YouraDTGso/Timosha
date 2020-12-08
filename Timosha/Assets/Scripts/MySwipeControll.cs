using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MySwipeControll : MonoBehaviour
{
    public bool isDraging;
    public Vector2 TapPoint, SwipeDelta;
    public float minSwipeDelta = 130;

    public enum MySwipeType
    { right, left, down, up }

    public delegate void MySwipe(MySwipeType type);
    public static MySwipe MySwipeEvent;
    
    void Awake()
    {
        isDraging = false;
        TapPoint = SwipeDelta = Vector2.zero;
    }    
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                TapPoint = Input.touches[0].position;
            }
            else if ((Input.touches[0].phase == TouchPhase.Canceled) || (Input.touches[0].phase == TouchPhase.Ended))
            {
                resetSwipe();
            }
        }

        CalculateSwipe();
    }

    public void CalculateSwipe()
    {
        SwipeDelta = Vector2.zero;

        if(isDraging && Input.touchCount > 0)
            SwipeDelta = (Input.touches[0].position - TapPoint);

        if (SwipeDelta.magnitude>minSwipeDelta && MySwipeEvent != null)
        {
            if (Mathf.Abs(SwipeDelta.x) > Mathf.Abs(SwipeDelta.y))
                MySwipeEvent(SwipeDelta.x < 0 ? MySwipeType.left : MySwipeType.right);
            else
                MySwipeEvent(SwipeDelta.y < 0 ? MySwipeType.down : MySwipeType.up);
            resetSwipe();
        }
    }

    public void resetSwipe()
    {
        isDraging = false;
        TapPoint = Vector2.zero;
    }


}
