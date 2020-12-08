using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    Animator camera_here;

    public bool pauseWas;
    public bool settingsWas;
    public bool backButton;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject pauseButton;
    public GameObject ScoreCount;
    public GameObject TransitToWorldButton;
    public GameObject ShotButton;

    public Text ScoreCountText;
    public int score;

    private void Start()
    {
        camera_here = GameObject.Find("Main Camera").GetComponent<Animator>();

        pauseButton.SetActive(false);
        ScoreCount.SetActive(false);
        score = 0;

        UpdateScore();

        pauseWas = false;
        settingsWas = false;
        backButton = false;
    }

    void Update()
    {
        score = SpheresSpawn.scoreIs;

        UpdateScore();

        if (pauseWas == false)
        {
            Resume();
        }

        else if(pauseWas == true)
        {
            Pause();
        }

         if (settingsWas == true)
        {
            settingsMenu();
        }
        else if (settingsWas == false && pauseWas == true)
        {
            Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        settingsWas = false;
        if (camera_here.GetBool("cb") == true)
        {
            pauseButton.SetActive(true);
            ScoreCount.SetActive(true);
            TransitToWorldButton.SetActive(true);
            if (CameraBackgoundColor.SpaceSky == true)
            {
                ShotButton.SetActive(true);
            }
            else 
            {
                ShotButton.SetActive(false);
            }
            
        }
        else
        {
            pauseButton.SetActive(false);
            ScoreCount.SetActive(false);
            TransitToWorldButton.SetActive(false);
            ShotButton.SetActive(false);
        }        
        Time.timeScale = 1;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        pauseButton.SetActive(false);
        ScoreCount.SetActive(false);
        TransitToWorldButton.SetActive(false);
        ShotButton.SetActive(false);
        Time.timeScale = 0f;
    }

    void settingsMenu()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        ScoreCount.SetActive(false);
        TransitToWorldButton.SetActive(false);
        ShotButton.SetActive(false);
        //pauseWas = false;
        Time.timeScale = 0f;
    }

    void UpdateScore()
    {
        ScoreCountText.text = "Energy  " + score;
    }
}

