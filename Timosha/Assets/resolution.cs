using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resolution : MonoBehaviour
{
    public Slider slider;

    public Toggle FHD;
    public Toggle HD;
    public Toggle FreeAspect;

    int fps;

    //public bool fhd;
    //public bool hd;
    //public bool freeAspect;
    void Start()
    {
        FHD.isOn = true;
        HD.isOn = false;
        FreeAspect.isOn = false;
    }

    void Update()
    {
        fps = Mathf.RoundToInt(slider.value * 100);

        if (FHD.isOn == true)
        {
            FHDFunc();
        }
        else if (HD.isOn==true)
        {
            HDFunc();
        }
        else if (FreeAspect.isOn==true)
        {
            FreeAspectFunc();
        }
    }

    void FHDFunc()
    {
        //FHD.isOn = true;
        HD.isOn = false;
        FreeAspect.isOn = false;
        Screen.SetResolution(1080, 2340, true, fps);
    }

    void HDFunc()
    {
        FHD.isOn = false;
        //HD.isOn = false;
        FreeAspect.isOn = false;
        Screen.SetResolution(720, 1560, true, fps);
    }

    void FreeAspectFunc()
    {
        FHD.isOn = false;
        HD.isOn = false;
        //FreeAspect.isOn = false;
    }
}
