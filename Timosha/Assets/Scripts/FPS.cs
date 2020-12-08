using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Slider slider;

    internal int fpsValue;
    
    void Start()
    {
        fpsValue = (int)slider.value;
        Application.targetFrameRate = fpsValue;
    }

    void Update()
    {
        fpsValue = (int)slider.value;
    }
}
