using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntoFight : MonoBehaviour {

    public MountainInformation mountainInformation;

    public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseUpAsButton()
    {
        if (!sceneName.Equals(""))
        {
            switch (sceneName)
            {
                case "6-1-0":
                    //for(int i = 0; i < 10; ++i)
                    //{
                    //    GlobalVariable.PlotItems.Add(GlobalVariable.AllGameItems["10018"]);
                    //}
                    if (FinalBossCondition())
                    {
                        GlobalVariable.currentScene = "6-1-0";
                        LoadConversation.SetConversation("6-1-0", 0, "fighting", "");
                    }
                    else
                    {
                        LoadConversation.SetConversation("6-0-0", 0, "ready", "");
                    }
                    break;
            }
        }
        else
        {
            GlobalVariable.currentScene = mountainInformation.serialnumber;
            if (GlobalVariable.StoreScenes.Contains(GlobalVariable.currentScene) && GlobalVariable.Chance(30))
            {
                SceneManager.LoadScene("store");
            }
            else
            {
                if (!GlobalVariable.JudgeMission(true))
                {
                    GlobalVariable.BeforeFight();
                }
            }
        }
    }

    bool FinalBossCondition()
    {
        int count = 0;
        foreach(GameProp item in GlobalVariable.PlotItems)
        {
            if (item.SerialNumber.Equals("10018"))
            {
                ++count;
            }
        }
        return count == 10;
    }
}
