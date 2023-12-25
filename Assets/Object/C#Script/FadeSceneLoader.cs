using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1.0f;

    public void CallFadeOutCoroutine(string nextScene)
    {
        StartCoroutine(FadeOutAndLoadScene(nextScene));
    }

    public void CallFadeInCoroutine()
    {
        StartCoroutine(FadeInAndLoadScene());
    }

    public IEnumerator FadeOutAndLoadScene(string nextScene)
    {
        fadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        fadePanel.color = endColor;
        SceneManager.LoadScene(nextScene);
    }

    public IEnumerator FadeInAndLoadScene()
    {
        fadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = Color.Lerp(endColor, startColor, t);
            yield return null;
        }

        fadePanel.color = startColor;
        //SceneManager.LoadScene(nextScene);
    }
}
