using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    //public Text LoadPercentege;

    //public Image LoadInProgressBar;
        
    public static SceneTransition instance;
    
    internal Animator componentAnimator;
    private AsyncOperation loadSceneAsync;

    public static void SwitchToScene(string sceneName)
    {
        //SceneTransition.SwitchToScene("sceneName");
        instance.componentAnimator.SetTrigger(name: "SceneStart");

        instance.loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);
        instance.loadSceneAsync.allowSceneActivation = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        componentAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAnimationOver()
    {        
        //loadSceneAsync.allowSceneActivation = true;
        //componentAnimator.SetBool("SceneExit", false);
    }
}
