using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;

    public List<GameLevels> gameLevels;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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
}
