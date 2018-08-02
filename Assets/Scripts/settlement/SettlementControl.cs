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
            if (AttributeUp.isLevelUp && !AttributeUp.isGetTalent)
            {
                LoadConversation.SetConversation("0-2-1", 0, "afterFight", "");
            }
            else if(AttributeUp.isLevelUp && AttributeUp.isGetTalent)
            {
                LoadConversation.SetConversation("0-2-2", 0, "afterFight", "");
            }
            else
            {
                GlobalVariable.AfterFight();
            }
            
            return;
        }
    }
}
