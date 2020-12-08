using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrasitionSecondVer : MonoBehaviour
{
    AsyncOperation asyncOperation;
    Animator scenetransit;
    //string sceneMain = "Scene_Main";
    string sceneSecond = "Scene_Second";

    void Start()
    {
        scenetransit = GetComponent<Animator>();
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;

        asyncOperation = SceneManager.LoadSceneAsync(sceneSecond);
        asyncOperation.allowSceneActivation = false;
        if (asyncOperation.isDone)
        {
            scenetransit.SetBool("SceneExit", false);
        }

        if (scenetransit.GetBool("SceneExit"))
        {
            yield return new WaitForSecondsRealtime(7);
            asyncOperation.allowSceneActivation = true;
        }
        yield return null;
    }

    public void OnAnimationOver()
    {
        asyncOperation.allowSceneActivation = true;
    }
}
