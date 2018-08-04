using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadFightData : MonoBehaviour {

    public bool isTest = false;
    string savePath;
    // Use this for initialization
    void Awake()
    {
        savePath = Application.persistentDataPath + "/illustration/illustrationSave.bin";
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
            LoadMergeReflect();
            LoadAllMissions();
            LoadAllLevel();
            LoadAllTalent();
            GlobalVariable.Realm = GlobalVariable.AllLevel[0];
            GlobalVariable.ExistingTalent.Add(GlobalVariable.AllTalent["001"]);
        }
        if (isTest)
        {
            LoadTestData();
        }
        LoadIllustrationSave();
    }

    void LoadIllustrationSave()
    {
        if (File.Exists(savePath))
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath,
                FileMode.Open);
            IllustrationSave save = (IllustrationSave)formatter.Deserialize(stream);
            if (save != null)
            {
                GlobalVariable.cardIllustration = save.CardIllustration;
                GlobalVariable.itemIllustration = save.ItemIllustration;
                GlobalVariable.monsterIllustration = save.MonsterIllustration;
            }
            stream.Close();
        }
    }

    void LoadTestData()
    {
        GlobalVariable.ExistingCards = new List<GameProp>(GlobalVariable.AllCards.Values);
        GlobalVariable.FightCards = new List<GameProp>(GlobalVariable.AllCards.Values);
        GlobalVariable.BattleItems = new List<GameProp>(GlobalVariable.AllGameItems.Values);
        GlobalVariable.ExistingLeadSkills = new List<GameProp>(GlobalVariable.AllLeadSkills.Values);
        List<GameProp> list = new List<GameProp>(GlobalVariable.AllLeadSkills.Values);
        for (int i = 0; i <= 2; ++i)
        {
            GlobalVariable.FightSkills[i] = list[i];
        }
        GlobalVariable.ExistingTalent = new List<Talent>(GlobalVariable.AllTalent.Values);
    }

    void LoadAllConversationList()
    {
        GlobalVariable.AllConversationList = LoadAllLineToList("conversation-list");
    }

    void LoadAllMissions()
    {
        Object[] allMissions = Resources.LoadAll("mission/missionDetails");
        foreach(Object mission in allMissions)
        {
            string[] missionDetails = mission.ToString().Split('\n');
            string[] missionTitle = missionDetails[0].Split('=');
            List<string> missionDescriptions = new List<string>();
            for(int i = 1; i < missionDetails.Length; ++i)
            {
                missionDescriptions.Add(missionDetails[i]);
            }
            GlobalVariable.AllMissions.Add(missionTitle[0], new Mission(missionTitle[0],
                0, missionTitle[1], missionDescriptions));
        }
    }

    void LoadAllTalent()
    {
        List<string> talents = LoadAllLineToList("ability");
        foreach(string talent in talents)
        {
            string[] talentDetails = talent.Split(',');
            GlobalVariable.AllTalent.Add(talentDetails[0], new Talent(talentDetails[0], talentDetails[1], talentDetails[2]));
        }
    }

    void LoadAllLevel()
    {
        List<string> levels = LoadAllLineToList("ability_level");
        foreach(string level in levels)
        {
            string[] levelDetails = level.Split('=');
            string talentNumber;
            if (levelDetails.Length == 2)
            {
                talentNumber = "";
            }
            else
            {
                talentNumber = levelDetails[2];
            }
            GlobalVariable.AllLevel.Add(new Level(float.Parse(levelDetails[0]), levelDetails[1], talentNumber));
        }
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
            Monster monsterObject = new Monster
                (monsterProps[0], monsterProps[1], monsterProps[2],
                float.Parse(monsterProps[3]), float.Parse(monsterProps[4]),
                int.Parse(monsterProps[5]), skills, int.Parse(monsterProps[7]),
                monsterProps[8], monsterProps[9]);
            GlobalVariable.AllMonsters.Add(monsterProps[0], monsterObject);
            GlobalVariable.monsterIllustration.Add(monsterObject.SerialNumber, false);
        }
    }

    void LoadGameProps(Dictionary<string, GameProp> gameProps, string fileName)
    {
        List<string> gameprops = LoadAllLineToList(fileName);
        foreach (string gameprop in gameprops)
        {
            List<string> props = new List<string>(gameprop.Split(new char[] { ',' }));
            GameProp gamePropObject = new GameProp(props[0],
                props[1], int.Parse(props[2]), props[3],
                props[4], float.Parse(props[5]), int.Parse(props[6]),
                int.Parse(props[7]), int.Parse(props[8]), props[9], props[10]);
            gameProps.Add(props[0], gamePropObject);
            switch (fileName)
            {
                case "card":
                    GlobalVariable.cardIllustration.Add(gamePropObject.SerialNumber, false);
                    break;
                case "item_battle":
                    GlobalVariable.itemIllustration.Add(gamePropObject.SerialNumber, false);
                    break;
                case "item_mission":
                    GlobalVariable.itemIllustration.Add(gamePropObject.SerialNumber, false);
                    break;
            }
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

    void LoadMergeReflect()
    {
        List<string> reflects = LoadAllLineToList("merge-reflect");
        foreach (string reflect in reflects)
        {
            List<string> formula = new List<string>(reflect.Split(new char[] { '=' }));
            GlobalVariable.mergeReflect.Add(formula[0], formula[1]);
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
