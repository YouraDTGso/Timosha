using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HD : MonoBehaviour
{
    public Slider slider;

    public Toggle FHD;
    public Toggle FreeAspect;

    int fps;


    public void Hdset()
    {
        fps = Mathf.RoundToInt(slider.value * 100);
        Screen.SetResolution(720, 1560, true, fps);
    }
}
