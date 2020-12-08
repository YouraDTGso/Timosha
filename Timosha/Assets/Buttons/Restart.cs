using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    PauseMenu pauseMenu;
    private void Start()
    {
        pauseMenu = GameObject.Find("Menu").GetComponent<PauseMenu>();
    }

    public void RestertLevel()
    {
        SceneManager.LoadScene("Scene_Second");
        pauseMenu.pauseWas = false;
    }

}
