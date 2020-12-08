using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Play_Button : MonoBehaviour
{
    public GameObject imagePlay;
    public GameObject imageOracle;
    public GameObject game_name;
    //public GameObject pauseButton;
    //public static bool pauseWas;
    
    public Animator camera_here;

    void Start()
    {
        camera_here = GameObject.Find("Main Camera").GetComponent<Animator>();

        imagePlay.SetActive(true);
        imageOracle.SetActive(true);
        game_name.SetActive(true);
    }

    private void Update()
    {
        
    }

    void OnMouseUpAsButton()
    {
        imagePlay.SetActive(false);
        imageOracle.SetActive(false);
        game_name.SetActive(false);

        camera_here.SetBool("cb", true);
    }

}
