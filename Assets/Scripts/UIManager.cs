using DG.Tweening;
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


    [Header("Pause Panel Options")]
    public GameObject pausePopUp;
    public GameObject pauseTitle;
    public GameObject pauseHomeBtn;
    public GameObject pauseRestartBtn;
    public GameObject pauseResumeBtn;

    public void OnClickPauseButton(bool active)
    {
        //pausePanel.SetActive(active);
        if (active)
            OpenPausePanel();
        else ClosePausePanel();
        Time.timeScale = !active ? 1 : 0;

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


    #region Tweener
    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        pausePopUp.transform.DOScale(1f, .5f).SetEase(Ease.OutQuad).SetUpdate(true).OnComplete(delegate
        {
            pauseTitle.transform.DOScale(1f, .5f).SetEase(Ease.OutQuad).SetUpdate(true).OnComplete(delegate
            {
                pauseHomeBtn.transform.DOScale(1f, .5f).SetEase(Ease.OutQuad).SetUpdate(true).OnComplete(delegate
                {
                    pauseRestartBtn.transform.DOScale(1f, .5f).SetEase(Ease.OutQuad).SetUpdate(true).OnComplete(delegate
                    {
                        pauseResumeBtn.transform.DOScale(1f, .5f).SetEase(Ease.OutQuad).SetUpdate(true).OnComplete(delegate
                        {

                        });
                    });
                });
            });
        });
    }

    public void ClosePausePanel()
    {
        pauseResumeBtn.transform.DOScale(0f, .5f).SetEase(Ease.InQuad).SetUpdate(true).OnComplete(delegate
        {
            pauseRestartBtn.transform.DOScale(0f, .5f).SetEase(Ease.InQuad).SetUpdate(true).OnComplete(delegate
            {
                pauseHomeBtn.transform.DOScale(0f, .5f).SetEase(Ease.InQuad).SetUpdate(true).OnComplete(delegate
                {
                    pauseTitle.transform.DOScale(0f, .5f).SetEase(Ease.InQuad).SetUpdate(true).OnComplete(delegate
                    {
                        pausePopUp.transform.DOScale(0f, .5f).SetEase(Ease.InQuad).SetUpdate(true).OnComplete(delegate
                        {
                            pausePanel.SetActive(false);
                        });
                    });
                });
            });
        });
    }

    #endregion

}
