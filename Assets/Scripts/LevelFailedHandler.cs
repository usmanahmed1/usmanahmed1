using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelFailedHandler : MonoBehaviour {

    [Header("LevelFailedButtons")]
    public GameObject MainMenuBtn;
    public GameObject RestartBtn;

    [Header("Others")]
    public GameObject StatsPannel;

    public GameObject Score;
    public Text ScoreText;

    public GameObject Cash;
    public Text CashText;

    private int tempScore;
    private int tempCash;

    private bool isTouchActivate = true;
    private bool isSecondTouchActive = false;

    private int TempVal = 0;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isTouchActivate && !isSecondTouchActive)
            {
                isTouchActivate = false;
                isSecondTouchActive = true;
                ScoreText.transform.DOKill();
                ScoreText.text = tempScore.ToString();
                AppearCash();
                Debug.Log("Touch 1");
            }

            if (!isTouchActivate && isSecondTouchActive)
            {
                isSecondTouchActive = true;
                CashText.transform.DOKill();
                CashText.text = tempCash.ToString();
                isTouchActivate = false;
                AppearBtns();
                Debug.Log("Touch 2");

            }

        }
    }

    
    public void StartScoreAppearance()
    {
        Debug.Log("LEVEL Failed SCRIPT ENTRY ");

        StatsPannel.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce);
        StartCoroutine(AppearScore());
        tempScore = int.Parse(ScoreText.text);
        tempCash = int.Parse(CashText.text);
        Debug.Log("Temp Coins are " + tempScore);
        Debug.Log("Temp Cash are " + tempCash);

    }



    private IEnumerator AppearScore()
    {

        yield return new WaitForSeconds(0.3f);

        Score.SetActive(true);
        Score.transform.DOScale(1.0f, 0.3f).SetEase(Ease.InOutBounce).OnComplete(delegate
        {
            ScoreText.gameObject.SetActive(true);
            isTouchActivate = true;

            ScoreText.transform.DOScale(1f, 0.05f).SetLoops((tempScore)).OnStepComplete(delegate
            {
                if (tempScore != 0)
                {
                    TempVal += 1;

                }
                ScoreText.text = TempVal.ToString();

            }).OnComplete(delegate {

                Debug.Log("Times Loop Begun....... " + TempVal);

                TempVal = 0;
                AppearCash();
                Debug.Log("Score Appear");
            });
        });

    }


    private void AppearCash()
    {


        Cash.SetActive(true);
        Cash.transform.DOScale(1.0f, 0.3f).SetEase(Ease.InOutBounce).OnComplete(delegate
        {
            CashText.gameObject.SetActive(true);
            isSecondTouchActive = true;

            CashText.transform.DOScale(1f, 0.05f).SetLoops((tempScore)).OnStepComplete(delegate
            {
                if (tempCash != 0)
                {
                    TempVal += 1;

                }

                CashText.text = TempVal.ToString();

            }).OnComplete(delegate {

                Debug.Log("Times Loop Begun....... " + TempVal);

                TempVal = 0;
                AppearBtns();
                Debug.Log("Score Appear");
            });

        });

    }


    private void AppearBtns()
    {
        MainMenuBtn.GetComponent<Image>().DOFillAmount(1f, 0.2f).OnComplete(delegate
        {
            RestartBtn.GetComponent<Image>().DOFillAmount(1f, 0.25f).OnComplete(delegate
            {
                //MonetizationManager.instance.ShowInterstitialMediation();
                if(UIManager.Instance.gData.RemoveAds == false)
                {
                   // ShowInterstitial
                }
                
            });
        });


    }


    public void ResetPositions()
    {
        Score.transform.DOScale(0f, 0.001f);
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
