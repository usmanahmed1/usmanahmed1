using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public GameData gData;
    [Header("Rate US Links")]
    public string RateUsAndriod = "";
    [Header("MoreApp Links")]
    public string MoreAppAndriod = "";
    [Header("privacy policy Link")]
    public string privacyPolicy;
    public GameObject nameBarText;
    [Header("Panels")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] public GameObject changeNamePanel;
    [SerializeField] private GameObject quitPanel;
    [SerializeField] private GameObject IAPPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private GameObject levelSelectionPanel;
    [Header("Setting Options")]
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject settingsBar;
    [SerializeField] private GameObject Sound;
    [SerializeField] private GameObject Music;
    [SerializeField] private GameObject info;
    [SerializeField] private GameObject store;
    [Header("Share Options")]
    [SerializeField] private GameObject share;
    [SerializeField] private GameObject shareBar;
    [SerializeField] private GameObject rateUs;
    [SerializeField] private GameObject gShare;
    [SerializeField] private GameObject moreGames;
    [SerializeField] private GameObject leaderBoard;
    [Header("Info Panel")]
    [SerializeField] private GameObject infoFG;
    [SerializeField] private GameObject infoLogo;
    [SerializeField] private GameObject InfoCross;
    [Header("INAppPurchasePanel")]
    [SerializeField] private GameObject IAPFG;
    [SerializeField] private GameObject IAPCrossButton;
    [SerializeField] private GameObject removeAllAds;
    [SerializeField] private GameObject removeTime;
    [SerializeField] private GameObject GetCash2000;
    [SerializeField] private GameObject GetCash5000;
    [SerializeField] private GameObject GetCash10000;
    [SerializeField] private GameObject removeAllAdsBtn;
    [SerializeField] private GameObject removeTimeBtn;
    [SerializeField] private GameObject GetCash2000Btn;
    [SerializeField] private GameObject GetCash5000Btn;
    [SerializeField] private GameObject GetCash10000Btn;
    private bool musicStatus, soundStatus;
    public Sprite MusicButtonEnable;
    public Sprite MusicButtonDisable;
    public Sprite SoundButtonEnable;
    public Sprite SoundButtonDisable;
    [Header("Change Name Panel")]
    [SerializeField]
    public GameObject nameFG, nameBar, nameOk, nameback;
    public Text cashText, starText;
    public GameObject parking;
    public InputField text;
    public int cash, stars;
    public bool soundcheck;

    public GameObject LevelSelectionPanel;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnClickPlayButton()
    {
        levelSelectionPanel.SetActive(true);
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
        //MonetizationManager.instance.ShowInterstitialMediation();

    }

    public void OnClickQuitPanel()
    {
        quitPanel.SetActive(true);
    }

    public void OnClickStoreButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        IAPPanel.SetActive(true);
        OpenIAPPanel();
    }

    public void OnClickIAPCrossButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        CloseIAPPanel();
    }


    public void OnClickExitYesButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        Application.Quit();
    }
    public void OnClickExitNoButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        quitPanel.SetActive(false);
    }
    public void OnClickInfoButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        infoPanel.SetActive(true);
        OpenInfoPanel();
    }
    public void OnInfoCrossButtonClick()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        CloseInfoPanel();
    }

    public void OnClickSettingsButton()
    {
        settingsPanel.SetActive(true);
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
    }

    public void OnClickShareButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        
    }

    public void OnClickNameBar()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        changeNamePanel.SetActive(true);
        if (string.IsNullOrEmpty(text.text))
        {
            nameOk.GetComponent<Button>().interactable = false;
        }

        OpenNamePanel();
    }
    public void OnClickNameOkayButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        string plName = text.text;
        if (!string.IsNullOrEmpty(plName))
        {
            nameOk.GetComponent<Button>().interactable = true;
            string name = text.text;
            nameBarText.transform.GetChild(0).gameObject.GetComponent<Text>().text = name;
            PlayerPrefs.SetString("name", name);
            gData.PlayerName = name;
            gData.SetPlayerName = true;
            PlayerPrefs.SetInt("SetPlayerName", 1);
            CloseNamePanel();
            //PlayFabManager.Instance.UpdatePlayerDisplayName();
            //PlayFabManager.Instance.SendGameData();
        }
    }
    public void OnClickMoreGamesButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
#if UNITY_ANDROID
        Application.OpenURL(MoreAppAndriod);
#elif UNITY_IOS
         Application.OpenURL(MoreAppiOS);
#endif
    }
    public void OnClickRateUsButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
#if UNITY_ANDROID
        Application.OpenURL(RateUsAndriod);
#elif UNITY_IOS
         Application.OpenURL(RateUsiOS);
#endif
    }

    public void OnClickPrivacyPolicyButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        Application.OpenURL(privacyPolicy);
    }

    public void OnClickLeaderBoardButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        leaderboardPanel.SetActive(true);
    }
    public void OnClickLeaderBoardCrossButton()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClick);
        leaderboardPanel.SetActive(false);
    }


    private void OpenIAPPanel()
    {
        IAPFG.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
        {
            removeAllAds.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
            {
                removeAllAdsBtn.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                {
                    removeTime.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                    {
                        removeTimeBtn.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                        {
                            GetCash2000.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate {
                                GetCash2000Btn.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                                {
                                    GetCash5000.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                                    {
                                        GetCash5000Btn.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                                        {
                                            GetCash10000.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                                            {
                                                GetCash10000Btn.transform.DOScale(1f, .2f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                                                {
                                                    IAPCrossButton.transform.DOScale(1f, .1f).SetEase(Ease.OutExpo).SetUpdate(true).OnComplete(delegate
                                                    {

                                                    });
                                                });
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });
    }
    private void CloseIAPPanel()
    {
        IAPPanel.SetActive(false);
        IAPCrossButton.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        GetCash10000Btn.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        GetCash10000.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        GetCash5000Btn.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        GetCash5000.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        GetCash2000Btn.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        GetCash2000.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        removeTimeBtn.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        removeTime.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        removeAllAdsBtn.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        removeAllAds.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
        IAPFG.transform.DOScale(0f, .5f).SetEase(Ease.InOutBounce);
    }
    public void OpenInfoPanel()
    {
        infoFG.transform.DOScale(1f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            infoLogo.transform.DOScale(1f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
            {
                InfoCross.transform.DOScale(1f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                {

                });
            });
        });
    }
    public void CloseInfoPanel()
    {
        InfoCross.transform.DOScale(0f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            infoLogo.transform.DOScale(0f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
            {
                infoFG.transform.DOScale(0f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                {
                    infoPanel.SetActive(false);
                });
            });
        });
    }
    public void OpenNamePanel()
    {
        Debug.Log("Into 1");
        nameFG.transform.DOScale(1f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            Debug.Log("Into 2");
            nameBar.transform.DOScale(1f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
            {
                Debug.Log("Into 3");
                nameOk.transform.DOScale(1f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                {

                });
            });
        });

    }
    public void CloseNamePanel()
    {
        nameOk.transform.DOScale(0f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            nameBar.transform.DOScale(0f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
            {
                nameFG.transform.DOScale(0f, .5f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                {
                    changeNamePanel.SetActive(false);
                });
            });
        });
    }
}
