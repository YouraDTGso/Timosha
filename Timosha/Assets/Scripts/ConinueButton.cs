using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConinueButton : MonoBehaviour
{
    PauseMenu pauseMenu;
    private void Start()
    {
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }

    public void PauseButtonNotActive()
    {
        pauseMenu.pauseWas = false;
    }
}
