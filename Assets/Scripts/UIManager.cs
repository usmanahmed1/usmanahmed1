using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    [Header("Game Data")]
    public GameData gData;

    [Header("Privacy Policy")]
    [SerializeField] private string privacyPolicyLink;

    [Header("Aim Image")]
    public Image aim;
    [Header("Hud Objective Text")]
    public Text hudObjTxt;
    public GameObject doorBtn;

    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject levelCompletePanel;
    public GameObject levelFailedPanel;
    public GameObject rewardedVideoPanel;
    public GameObject unlockCodePanel;
    public GameObject objectivePanel;

    public void OnClickPauseButton(bool active)
    {
        Time.timeScale = active ? 1 : 0;
        pausePanel.SetActive(active);
    }

    public void OnClickRestartButton()
    {
        GameManager.Instance.ChangeScene("Loading");
    }

    public void OnClickNextButton()
    {
        GameManager.Instance.LevelSelected++;
        GameManager.Instance.ChangeScene("Loading");
    }

    public void OnClickHomeButton()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void UpdateTimeScale(int timeScale = 0)
    {
        Time.timeScale = timeScale;
    }

    public void OnClickDoorBtn()
    {
        PlayerController.Instance.OpenDoor();
    }

}
