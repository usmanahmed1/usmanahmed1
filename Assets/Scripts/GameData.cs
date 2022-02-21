using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/GameSettings/GameData", fileName = "GameData")]
public class GameData : ScriptableObject
{
    public bool RemoveAds;
    public int TotalCash;
    public int TotalScore;
    public int LevelCompleted;

    public string PlayerName;
    public bool SetPlayerName;
}
