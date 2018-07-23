using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour {

    bool isEscaped = false;
    public int demarcationline;
    public GameControll gameControll;
    // Use this for initialization
    void Start () {
        demarcationline = 50;
        if (GlobalVariable.currentScene.StartsWith("0"))
        {
            demarcationline = 0;
        }
	}
    

    private void OnMouseDown()
    {
        if (!isEscaped)
        {
            if (GlobalVariable.Chance(demarcationline))
            {
                SceneManager.LoadScene("tertiaryMap");
            }
            else
            {
                gameControll.SetTip("逃跑失败");
                isEscaped = true;
            }
        }
        else
        {
            gameControll.SetTip("已经逃跑过了");
        }
    }
}
