using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;
    public GameObject mainPlayer;
    public GameObject cutSceneCamera;
    public List<GameLevels> gameLevels;
    public GameObject directionalLight;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {
        ActivateCutScenes();
    }

    public void ActivatePlayerandSetPositions()
    {
        mainPlayer.SetActive(true);
        mainPlayer.transform.position = gameLevels[GameManager.Instance.LevelSelected].playerPos.position;
        mainPlayer.transform.rotation = gameLevels[GameManager.Instance.LevelSelected].playerPos.rotation;
    }


    public void ActivateCutScenes()
    {
        cutSceneCamera.SetActive(true);
        directionalLight.SetActive(true);
        UIManager.Instance.SetMainObjective();
    }

    public void ActivateObjectives(Text objText)
    {
        objText.GetComponent<TextDisplayManager>().startTyping(objText, gameLevels[GameManager.Instance.LevelSelected].mainObj, 0.5f);
    }

    public void AfterCompleteFade()
    {
        ActivatePlayerandSetPositions();
        UIManager.Instance.SetObjective();
    }
}

[Serializable]
public class GameLevels
{
    public string LevelNo;
    public int levelTime;
    public string mainObj;
    public List<string> objectives;
    public Transform playerPos;
    public Transform enemyPos;
    internal int tempTime;
    public AnimationClip animClip;
}
