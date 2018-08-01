using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettlementControl : MonoBehaviour {
    public GameObject monsterInfo;
    public GameObject itemReward;
    public GameObject cardReward;
    public GameObject attributeReward;
    bool isFirstClick = false;
    bool isSecondClick = false;
    bool isThridClick = false;
    bool isFourthClick = false;
    bool isFirstUp = true;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isFirstClick)
        {
            isFirstClick = true;
            Destroy(monsterInfo);
            itemReward.SetActive(true);
            return;
        }
        if(Input.GetMouseButtonDown(0) && isFirstClick && !isSecondClick)
        {
            isSecondClick = true;
            Destroy(itemReward);
            cardReward.SetActive(true);
            return;
        }
        if (Input.GetMouseButtonDown(0) && isSecondClick && !isThridClick)
        {
            isThridClick = true;
            Destroy(cardReward);
            attributeReward.SetActive(true);
            return;
        }
        if (Input.GetMouseButtonDown(0) && isThridClick && !isFourthClick && AttributeUp.isUp)
        {
            if (isFirstUp &&
                !GlobalVariable.HasFightScenes.Contains(GlobalVariable.currentScene))
            {
                isFirstUp = false;
                return;
            }
            Destroy(attributeReward);
            AttributeUp.isUp = false;

            if (HasBoss())
            {
                GlobalVariable.HasFightBossScenes.Add(GlobalVariable.currentScene);
                if (HasAreaBoss())
                {
                    GlobalVariable.HasFightAreaBoss.Add(GlobalVariable.preMap, true);
                }
            }
            if (GlobalVariable.AllConversationList.Contains(GlobalVariable.currentScene + "-1"))
            {

                if (GlobalVariable.currentScene.StartsWith("0"))
                {
                    if (int.Parse(GlobalVariable.currentScene.Split('-')[2]) < 3)
                    {
                        LoadConversation.SetConversation(GlobalVariable.currentScene, 1, "conversation", "");
                    }
                    else
                    {
                        TertiaryMapSelect.SetScene("1-1");
                        LoadConversation.SetConversation(GlobalVariable.currentScene, 1, "tertiaryMap", "");
                    }
                }
                else
                {
                    if (!GlobalVariable.HasFightScenes.Contains(GlobalVariable.currentScene))
                    {
                        LoadConversation.SetConversation(GlobalVariable.currentScene, 1, "tertiaryMap", "");
                    }
                    else
                    {
                        TertiaryMapSelect.SetScene(GlobalVariable.preMap);
                        SceneManager.LoadScene("tertiaryMap");
                    }
                }
            }
            else
            {
                TertiaryMapSelect.SetScene(GlobalVariable.preMap);
                SceneManager.LoadScene("tertiaryMap");
            }
            GlobalVariable.HasFightScenes.Add(GlobalVariable.currentScene);
            GlobalVariable.Mountains[GlobalVariable.currentScene].status = true;
            return;
        }
    }

    bool HasBoss()
    {
        foreach(string number in GlobalVariable.sceneMonsterNumber)
        {
            if (number.StartsWith("2"))
            {
                return true;
            }
        }
        return false;
    }

    bool HasAreaBoss()
    {
        List<string> areaBoss = new List<string>{ "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008" };
        foreach (string number in GlobalVariable.sceneMonsterNumber)
        {
            if (areaBoss.Contains(number))
            {
                return true;
            }
        }
        return false;
    }
}
