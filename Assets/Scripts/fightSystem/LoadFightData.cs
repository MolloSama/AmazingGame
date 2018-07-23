﻿using System.Collections.Generic;
using UnityEngine;

public class LoadFightData : MonoBehaviour {

    public bool isTest = false;
    // Use this for initialization
    void Awake()
    {
        GlobalVariable.ClearGameData();
        if(GlobalVariable.AllCards.Count == 0)
        {
            LoadSceneMonsters();
            LoadGameProps(GlobalVariable.AllCards, "card");
            LoadGameProps(GlobalVariable.AllGameItems, "item_battle");
            LoadGameProps(GlobalVariable.AllMonstersSkills, "monster_skill");
            LoadGameProps(GlobalVariable.AllLeadSkills, "skill");
            LoadAllMonsters();
            LoadAllStates();
            LoadGameProps(GlobalVariable.AllGameItems, "item_mission");
            LoadMountain();
            LoadAllConversationList();
        }
        if (isTest)
        {
            LoadTestData();
        }
        
    }


    // Update is called once per frame
    void Update () {
		
	}

    void LoadTestData()
    {
        GlobalVariable.ExistingCards = new List<GameProp>(GlobalVariable.AllCards.Values);
        GlobalVariable.FightCards = new List<GameProp>(GlobalVariable.AllCards.Values);
        GlobalVariable.BattleItems = new List<GameProp>(GlobalVariable.AllGameItems.Values);
        List<GameProp> list = new List<GameProp>(GlobalVariable.AllLeadSkills.Values);
        for (int i = 0; i <= 2; ++i)
        {
            GlobalVariable.FightSkills[i] = list[i];
        }
    }

    void LoadAllConversationList()
    {
        GlobalVariable.AllConversationList = LoadAllLineToList("conversation-list");
    }

    void LoadMountain()
    {
        string[] positionData = Resources.Load("data/mountain_position").ToString().Split('\n');
        string[] nameData = Resources.Load("data/num-mount-reflect").ToString().Split('\n');
        int count = 0;
        foreach (string t in positionData)
        {
            string[] temp = t.Split(' ');
            for (int i = 1; i < temp.Length; i += 2)
            {
                //GlobalVariable.Secondary_Map_Serialnumber.Add(nameData[count].Split('=')[0].Split('-')[0] + '-' + nameData[count].Split('=')[0].Split('-')[1]);
                MountainInformation mountain = new MountainInformation(nameData[count].Split('=')[0], nameData[count].Split('=')[1], float.Parse(temp[i]), float.Parse(temp[i + 1]), false, (i / 2 + 1));
                GlobalVariable.Mountains.Add(mountain.serialnumber, mountain);
                count++;
            }
        }
    }

    void LoadAllStates()
    {
        List<string> states = LoadAllLineToList("state");
        foreach(string state in states)
        {
            List<string> stateProps = new List<string>(state.Split(new char[] { ',' }));
            GlobalVariable.AllStates.Add(stateProps[1], new Status(int.Parse(stateProps[0]), 
                stateProps[1], stateProps[2], float.Parse(stateProps[3]), int.Parse(stateProps[4])));
        }
    }

    void LoadAllMonsters()
    {
        List<string> monsters = LoadAllLineToList("monster");      
        foreach (string monster in monsters)
        {
            List<string> monsterProps = new List<string>(monster.Split(new char[] { ',' }));
            List<GameProp> skills = new List<GameProp>();
            List<string> skillNumbers = new List<string>(monsterProps[6].Split(new char[] { ' ' }));
            skillNumbers[0] = skillNumbers[0].Trim(new char[] { '[' });
            skillNumbers[skillNumbers.Count - 1] = 
                skillNumbers[skillNumbers.Count - 1].Trim(new char[] { ']' });
            foreach(string number in skillNumbers)
            {
                skills.Add(GlobalVariable.AllMonstersSkills[number]);
            }
            GlobalVariable.AllMonsters.Add(monsterProps[0], new Monster
                (monsterProps[0], monsterProps[1], monsterProps[2],
                float.Parse(monsterProps[3]), float.Parse(monsterProps[4]), 
                int.Parse(monsterProps[5]), skills, int.Parse(monsterProps[7]), 
                monsterProps[8], monsterProps[9]));
        }
    }

    void LoadGameProps(Dictionary<string, GameProp> gameProps, string fileName)
    {
        List<string> gameprops = LoadAllLineToList(fileName);
        foreach (string gameprop in gameprops)
        {
            List<string> props = new List<string>(gameprop.Split(new char[] { ',' }));
            gameProps.Add(props[0], new GameProp(props[0], 
                props[1], int.Parse(props[2]), props[3], 
                props[4], float.Parse(props[5]), int.Parse(props[6]), 
                int.Parse(props[7]), int.Parse(props[8]), props[9], props[10]));
        }
    }

    void LoadSceneMonsters()
    {
        List<string> scenes = LoadAllLineToList("scene-mosters");
        foreach (string scene in scenes)
        {
            List<string> sceneMosters = new List<string>(scene.Split(new char[] { '=' }));
            List<string> mosters = new List<string>(sceneMosters[1].Split(new char[] { ',' }));
            GlobalVariable.sceneMonstersDictionary.Add(sceneMosters[0], mosters);
        }
    }

    List<string> LoadAllLineToList(string fileName)
    {
        List<string> list = new List<string>();
        string texts = Resources.Load("data/"+fileName).ToString();
        using (System.IO.StringReader reader = new System.IO.StringReader(texts))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }
        }
        return list;
    }
}
