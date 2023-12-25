using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public FadeSceneLoader fadeSceneLoader;

    private void Start()
    {
        fadeSceneLoader.CallFadeInCoroutine();
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;
    }

    public void ChangeScene(string nextScene)
    {
        fadeSceneLoader.CallFadeOutCoroutine(nextScene);
        //SceneManager.LoadScene(nextScene);
    }

    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
}
