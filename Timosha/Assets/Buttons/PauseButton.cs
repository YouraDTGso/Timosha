using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    PauseMenu pauseMenu;

    private void Start()
    {
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }
    public void PauseButtonActive()
    {
        pauseMenu.pauseWas = true;
    }
}
