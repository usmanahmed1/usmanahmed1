using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CutScenesAnimationController : MonoBehaviour
{
    public Animation anim;

    private AnimationClip animClip;

    public void Start()
    {
        anim = GetComponent<Animation>();
        PlayAnimation();
    }

    public void PlayAnimation()
    {
        animClip = GamePlayManager.Instance.gameLevels[GameManager.Instance.LevelSelected].animClip;
        anim.clip = animClip;
        anim.AddClip(animClip, animClip.name);
        anim.Play();

        AfterCompleteCutScene();
    }

    public async void AfterCompleteCutScene()
    {
        var len = animClip.length;
        await Task.Delay(TimeSpan.FromSeconds(len));
        ShowFadeImage();
    }

    public void ShowFadeImage()
    {
        UIManager.Instance.fadeImage.SetActive(true);
        UIManager.Instance.fadeImage.GetComponent<FadeImage>().StartFade();
    }
}
