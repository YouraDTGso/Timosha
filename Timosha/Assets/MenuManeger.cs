using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour
{
    SceneTransition sceneTransition;
    // Start is called before the first frame update
    void Start()
    {
        sceneTransition = GetComponent<SceneTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name== "Scene_Main")
        {
            SceneTransition.SwitchToScene("Scene_Main");
        }
    }

    public void GoToGame()
    {
        SceneTransition.SwitchToScene("Scene_Main");
    }
}
