using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFile : MonoBehaviour {
    public SaveControl saveControl;
	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        if (saveControl.saveNumberReflect.ContainsKey(MoveBorder.currentIndex))
        {
            LoadGameData(saveControl.saveNumberReflect[MoveBorder.currentIndex]);
            string[] number = GlobalVariable.currentScene.Split('-');
            
            if (number[0].Equals("0"))
            {
                GlobalVariable.topMap = "1";
                GlobalVariable.middleMap = "1-1";
            }
            else
            {
                GlobalVariable.topMap = number[0];
                GlobalVariable.middleMap = number[0] + "-" + number[1];
            }
            
            SceneManager.LoadScene("ready");
        } 
    }

    void LoadGameData(SaveModel save)
    {
        GlobalVariable.ExistingCards = save.ExistCards;
        GlobalVariable.FightCards = save.FightCards;
        GlobalVariable.ExistingLeadSkills = save.ExistSkill;
        GlobalVariable.FightSkills = save.FightSkill;
        GlobalVariable.BattleItems = save.BattleItems;
        GlobalVariable.PlotItems = save.PlotItems;
        GlobalVariable.kraKen = save.Kraken;
        GlobalVariable.HasFightZSBossScenes = save.HasFightZSBossScenes;
        GlobalVariable.HasFightBossScenes = save.HasFightBossScenes;
        GlobalVariable.HasFightScenes = save.HasFightScenes;
        GlobalVariable.HasFightAreaBossScenes = save.HasFightAreaBossScenes;
        GlobalVariable.currentScene = save.CurrentScenes;
        GlobalVariable.LeadName = save.LeadName;
        GlobalVariable.Realm = save.Realm;
        GlobalVariable.ExistingTalent = save.ExistTalents;
        GlobalVariable.ExistingMissions = save.ExistMissinos;
        GlobalVariable.AllMissions = save.AllMissions;
        GlobalVariable.money = save.Money;
        GlobalVariable.FightCardsIndex = save.FightCardsIndex;
        GlobalVariable.sceneflag = save.Sceneflag;
    }
}
