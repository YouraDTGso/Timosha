using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasitToWorldButton : MonoBehaviour
{

    public void TransitToWorld()
    {
        CameraBackgoundColor.SpaceSky = !CameraBackgoundColor.SpaceSky;
    }

}
