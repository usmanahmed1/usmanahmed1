using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int LevelSelected;
    public GameData gData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnlockLevels(int levelIndex)
    {
        int currentLevel = PlayerPrefs.GetInt("unlockLevel");
        //currentLevel = Gdata.LevelCompleted;
        if (levelIndex >= currentLevel)
        {
            Debug.Log("Unlock 1 = " + levelIndex);
            PlayerPrefs.SetInt("unlockLevel", levelIndex




                );
        }
        if (levelIndex > gData.LevelCompleted)
        {
            gData.LevelCompleted = levelIndex;
            //PlayFabManager.Instance.SendGameData();
        }
    }

}
