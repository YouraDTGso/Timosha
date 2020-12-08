using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragButton : MonoBehaviour, IDragHandler
{
    [SerializeField] RectTransform DragButon;

    [SerializeField] Canvas canvas;

    public void OnDrag(PointerEventData eventData)
    {
        DragButon.anchoredPosition += eventData.delta / canvas.scaleFactor;

        LikeTarget.WasClickOnTarget = true;
        Debug.Log("ShotActive");
    }

    public void OnMouseUp()
    {
        LikeTarget.WasClickOnTarget = false;
        Debug.Log("ShotStop");
    }
}



