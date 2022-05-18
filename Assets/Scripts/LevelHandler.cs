using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public List<GameObject> levelButtons;
    public Button lvlNextBtn;

    public void Start()
    {
        for (int i = 0; i < levelButtons.Count; i++)
        {
            levelButtons[i].GetComponent<Level>().SetProperties(i);
        }
    }

    void Update()
    {
        lvlNextBtn.interactable = GameManager.Instance.LevelSelected != -1;
    }

    public void OnClickLevelNextButton()
    {
        if (GameManager.Instance.LevelSelected != -1)
        {
            GameManager.Instance.ChangeScene("Loading");
        }
    }

    public void OnClickBackButton()
    {
        if (GameManager.Instance.LevelSelected != -1)
            levelButtons[GameManager.Instance.LevelSelected].GetComponent<Level>().outline.enabled = false;
        GameManager.Instance.LevelSelected = -1;
        gameObject.SetActive(false);
    }
}
