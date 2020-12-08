using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FHD : MonoBehaviour
{
    public Slider slider;

    public Toggle HD;
    public Toggle FreeAspect;

    int fps;


    public void fhdset()
    {
        fps = Mathf.RoundToInt(slider.value * 100);
        Screen.SetResolution(1080, 2340, true, fps);
    }
}
