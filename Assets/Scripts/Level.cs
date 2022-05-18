using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    int index;
    public Image outline;
    public GameObject overlay;
    public GameObject lockImg;
    public void OnEnable()
    {
        GetComponentInChildren<Button>().onClick.AddListener(OnClickLevelButton);
    }
    void Start()
    {
        /*GetComponentInChildren<Text>().text = setName();*/
    }

    public void SetProperties(int index)
    {
        this.index = index;
        GetComponentInChildren<Text>().text = (index + 1).ToString();
    }

    string setName()
    {
        string txt = gameObject.name;
        txt = txt.Replace("Level ", "");
        txt = txt.Replace("(", "");
        txt = txt.Replace(")", "");
        return txt;
    }

    public void OnClickLevelButton()
    {
        var lvl = LevelHandler.Instance.levelButtons;
        if(GameManager.Instance.LevelSelected != -1)
            lvl[GameManager.Instance.LevelSelected].GetComponent<Level>().outline.enabled = false;
        GameManager.Instance.LevelSelected = index;
        outline.enabled = true;
    }

    public void OnDisable()
    {
        GetComponentInChildren<Button>().onClick.RemoveListener(OnClickLevelButton);
    }
}
