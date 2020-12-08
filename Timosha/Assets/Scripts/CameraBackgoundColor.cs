using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgoundColor : MonoBehaviour
{
    PauseMenu pauseMenu;

    public Material BigSphere;
    public Material startsSky;
    public new Light light;
    public Material BlockInSpace;

    [SerializeField] [Range(0f, 1f)] float lerpTime;

    [SerializeField]
    Color[] myColors;
    int colorIndex = 0;

    float skyspeed = 1f;
    public static bool SpaceSky;

    float t = 0f;

    int len;

    void Start()
    {
        len = myColors.Length;
        SpaceSky = false;
    }

    void Update()
    {
        Camera.main.backgroundColor =
               Color.Lerp(Camera.main.backgroundColor, myColors[colorIndex], lerpTime * Time.fixedDeltaTime);

        startsSky.SetColor("_Tint", Camera.main.backgroundColor);
        startsSky.SetFloat("_Exposure", 3f);

        startsSky.SetFloat("_Rotation", Time.time * skyspeed);

        BigSphere.SetColor("_EmissionColor",
                Camera.main.backgroundColor);
        BigSphere.SetColor("_Color",
                Camera.main.backgroundColor);

        BlockInSpace.SetColor("_Color",
                Camera.main.backgroundColor);
        if (SpaceSky==true)
        {
            Camera.main.clearFlags = CameraClearFlags.Skybox;
            light.intensity = 2.5f;

            light.color = Camera.main.backgroundColor;
        }
        else if (SpaceSky == false)
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;            
            light.intensity = .7f;

            light.color = new Color(1f, .93f, .67f);
        }
        

        if (SpheresSpawn.scoreIs==30 && SpaceSky == true)
        {
            //Camera.main.clearFlags = CameraClearFlags.Skybox;
            //light.intensity = 2.5f;
            //SpaceSky = true;
        }

        else if (SpaceSky == false)
        {
            //Camera.main.clearFlags = CameraClearFlags.SolidColor;            
            //light.intensity = .7f;
            //SpaceSky = false;
        }       

        t = Mathf.Lerp(t, 1f, lerpTime*Time.fixedDeltaTime);

        if (t>.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }

    }
}
