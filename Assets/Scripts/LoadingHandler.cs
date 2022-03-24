using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingHandler : MonoBehaviour
{
    [Header("Slider")]
    public Image slider;
    [Header("Percentage Text")]
    public Text percentage;
    private void Start()
    {
        StartCoroutine(LoadScene());

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.ChangeScene("MainMenu");
        }
    }
    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GamePlay");
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.009f);
            /*print(progress);
            slider.fillAmount = 0f;
            percentage.text = "% " + progress * 100;*/
            yield return null;
        }
    }
}
