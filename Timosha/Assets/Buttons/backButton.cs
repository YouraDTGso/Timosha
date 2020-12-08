using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton : MonoBehaviour
{
    PauseMenu pauseMenu;
    private void Start()
    {
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }

    public void backButtonActive()
    {
        pauseMenu.settingsWas = false;
        pauseMenu.backButton = true;
    }
}
