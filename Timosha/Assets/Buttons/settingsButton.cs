using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsButton : MonoBehaviour
{
    PauseMenu pauseMenu;
    private void Start()
    {
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }

    public void SettingsButtonActive()
    {
        pauseMenu.settingsWas = true;
        pauseMenu.backButton = false;
    }
}
