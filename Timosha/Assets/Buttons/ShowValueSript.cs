using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValueSript : MonoBehaviour
{
    Text fpsCount;

    void Start()
    {
        fpsCount = GetComponent<Text>();
    }

    public void textUpdate(float value)
    {
        fpsCount.text = Mathf.RoundToInt(value * 100)+"";
    }
}
