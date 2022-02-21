using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public bool startTimer;
    
    public float timeLeft;
    public Text text;
    [HideInInspector]
    public bool clock;

    public bool watchVideo;

    public bool LevelCompleteOrFailed = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        if (startTimer)
        {
            InitializeTime();
        }
    }


    public void InitializeTime()
    {
        timeLeft = GamePlayManager.Instance.gameLevels[GameManager.Instance.LevelSelected].levelTime;
    }

    public void Update()
    {
        if (startTimer)
        {
            if (!LevelCompleteOrFailed)
            {
                if (timeLeft > 0 && clock == false)
                {
                    clock = true;
                    StartCoroutine(Wait());
                }
            }
            if (timeLeft <= 10)
            {
                // Check if Ads available
            }
        }
    }


    IEnumerator wait()
    {
        UIManager.Instance.UpdateTimeScale();
        if (watchVideo)
        {
            //UIManager.Instance.OpenWatchVideo();
            //UIManager.Instance.AnimateVideoButton();
        }
        else
        {
            yield return new WaitForSecondsRealtime(1f);
            UIManager.Instance.levelFailedPanel.SetActive(true);
            UIManager.Instance.levelFailedPanel.GetComponent<LevelFailedHandler>().StartScoreAppearance();
        }
    }
    IEnumerator Wait()
    {
        timeLeft -= 1;

        UpdateTimer();
        yield return new WaitForSeconds(1);
        if (timeLeft == 0)
        {
            StartCoroutine(wait());
        }
        else
        {
            clock = false;
        }



    }

    void UpdateTimer()
    {
        int min = Mathf.FloorToInt(timeLeft / 60);
        int sec = Mathf.FloorToInt(timeLeft % 60);
        text.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00");
        GamePlayManager.Instance.gameLevels[GameManager.Instance.LevelSelected].tempTime = Mathf.FloorToInt(timeLeft);
    }
}
