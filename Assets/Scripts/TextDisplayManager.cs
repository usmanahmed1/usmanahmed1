using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayManager : MonoBehaviour
{
    public string textToDisplay;
    public Text txt;
    public float timePerCharacter;
    float timer;
    int chIndex = 0;

    public void startTyping(Text txt, string txtToWrite, float timePerCh)
    {
        this.txt = txt;
        textToDisplay = txtToWrite;
        timePerCharacter = timePerCh;
        chIndex = 0;
    }

    public void Update()
    {
        if(txt != null)
        {
            timer -= Time.deltaTime * 5;
            if(timer <= 0f)
            {
                timer += timePerCharacter;
                chIndex++;
                txt.text = textToDisplay.Substring(0, chIndex);

                if(chIndex >= textToDisplay.Length)
                {
                    txt = null;
                    return;
                }
            }
        }
    }
}
