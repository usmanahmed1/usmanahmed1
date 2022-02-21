using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelCompleteHandler : MonoBehaviour {

    [Header("LevelCompleteButtons")]
    public GameObject MainMenuBtn;
    public GameObject RestartBtn;
    public GameObject NextLevelBtn;

    [Header("Others")]
    public GameObject StatsPannel;

    public GameObject Score1;
    public Text ScoreText;

    public GameObject Cash;
    public Text CashText;

    public GameData Gdata;

    private int tempScore;
    private int tempCash;

    private bool isTouchActivate = false;
    private bool isSecondTouchActive = false;

    private int TempVal = 0;
    int score, cash;
    void Hello()
    {
        if (Input.GetMouseButton(0))
        {
            if (isTouchActivate && !isSecondTouchActive )
            {
                isTouchActivate = false;
                isSecondTouchActive = true;
                ScoreText.transform.DOKill();
                ScoreText.text = tempScore.ToString();
                Debug.Log("Touch 1");
            }

            if (!isTouchActivate && isSecondTouchActive )
            {
                isSecondTouchActive = false;
                CashText.transform.DOKill();
                CashText.text = tempCash.ToString();

                isTouchActivate = false;
                //AppearBtns();
                Debug.Log("Touch 2");

            }

        }
    }

    public void CalculateScore()
    {
        float remainingTime = GamePlayManager.Instance.gameLevels[GameManager.Instance.LevelSelected - 1].tempTime;
        float totalTime = GamePlayManager.Instance.gameLevels[GameManager.Instance.LevelSelected - 1].levelTime;
        //score = Mathf.FloorToInt(remainingTime + totalTime * 20 + MenuManager.Instance.levelStars[GameManager.instance.LevelSelected - 1]);
        if (score < 0)
        {
            score = 0;
        }
            cash = score / 200;
    }



    public void StartScoreAppearance()
    {
        Debug.Log("LEVEL COMPLETE SCRIPT ENTRY " );

        StatsPannel.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            StartCoroutine(AppearScore());
            ScoreText.text = score.ToString();
            CashText.text = cash.ToString();
            tempScore = int.Parse(ScoreText.text);
            tempCash = int.Parse(CashText.text);
            Debug.Log("TEMP CASH IS" + tempCash);
            Debug.Log("Temp Coins are " + tempScore);
            Debug.Log("Temp Cash are " + tempCash);
        });
    }



    private IEnumerator AppearScore()
    {

        yield return new WaitForSecondsRealtime(0.3f);

        Score1.SetActive(true);
        Score1.transform.DOScale(1.0f, 0.3f).SetEase(Ease.InOutBounce).SetUpdate(true).OnComplete(delegate
        {
            ScoreText.gameObject.SetActive(true);
            isTouchActivate = true;

            ScoreText.transform.DOScale(1f, .05f).SetUpdate(true).OnComplete(delegate { 
                TempVal = 0;
                AppearCash();
            });

        });

    }


    private void AppearCash()
    {


        Cash.SetActive(true);
        Cash.transform.DOScale(1.0f, 0.3f).SetUpdate(true).OnComplete(delegate
        {
            CashText.gameObject.SetActive(true);
            CashText.transform.DOScale(1f, 0.05f).SetUpdate(true).OnComplete(delegate
            {
                TempVal = 0;
                AppearBtns();
            });

        });

    }


    private void AppearBtns()
    {
        MainMenuBtn.transform.DOScale(1f, 0.2f).OnComplete(delegate
        {
            RestartBtn.transform.DOScale(1f, 0.2f).OnComplete(delegate
            {
                if (GameManager.Instance.LevelSelected != 29)
                {
                    NextLevelBtn.transform.DOScale(1f, 0.2f).OnComplete(delegate
                    {
                        //MonetizationManager.instance.ShowInterstitialMediation();
                    });
                }
                else if(GameManager.Instance.LevelSelected == 29)
                {
                    //MonetizationManager.instance.ShowInterstitialMediation();
                }
                
            });

            
        });
        Gdata.TotalCash += int.Parse(CashText.text);
        Gdata.TotalScore += int.Parse(ScoreText.text);
    }


    public void ResetPositions()
    {
        Score1.transform.DOScale(0f, 0.001f);
        Cash.transform.DOScale(0f, 0.001f);
        ScoreText.transform.DOScale(0f, 0.001f);
        CashText.transform.DOScale(0f, 0.001f);
        StatsPannel.transform.DOScale(0f, 0.001f);
        

        isTouchActivate = false;
        isSecondTouchActive = false;

        tempCash = 0;
        tempScore = 0;
    }

}
