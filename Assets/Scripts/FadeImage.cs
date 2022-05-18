using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public void StartFade()
    {
        GetComponent<Image>().enabled = true;
        GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
        StartCoroutine(FadeOut());
    }
    public void FadeIn()
    {
        GetComponent<Image>().CrossFadeAlpha(1, 2, false);
    }
    IEnumerator FadeOut()
    {
        FadeIn();
        yield return new WaitForSecondsRealtime(2f);
        GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
        GetComponent<Image>().CrossFadeAlpha(0, 2, false);
        UIManager.Instance.objectivePanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        UIManager.Instance.cf2Panel.SetActive(true);
        GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(1);
        GamePlayManager.Instance.cutSceneCamera.SetActive(false);
        GamePlayManager.Instance.directionalLight.SetActive(false);
        GamePlayManager.Instance.AfterCompleteFade();
        gameObject.SetActive(false);
    }
}