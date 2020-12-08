using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeAspect : MonoBehaviour
{
    public Slider slider;

    public Toggle FHD;
    public Toggle HD;

    int fps;


    public void FreeSet()
    {
        fps = Mathf.RoundToInt(slider.value * 100);
        Screen.SetResolution(1080, 1920, true, fps);
    }
}
