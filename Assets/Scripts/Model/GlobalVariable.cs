using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GlobalVariable{

    public static Dictionary<string, GameProp> AllCards = new Dictionary<string, GameProp>();
    public static List<GameProp> ExistingCards = new List<GameProp>();
    public static List<GameProp> FightCards = new List<GameProp>();
    public static Dictionary<string, GameProp> AllGameItems = new Dictionary<string, GameProp>();
    public static List<GameProp> BattleItems = new List<GameProp>();
    public static List<GameProp> PlotItems = new List<GameProp>();
    public static Dictionary<string, GameProp> AllLeadSkills = new Dictionary<string, GameProp>();
    public static List<GameProp> ExistingLeadSkills = new List<GameProp>();
    public static GameProp[] FightSkills = new GameProp[3];
    public static Dictionary<string, GameProp> AllMonstersSkills = new Dictionary<string, GameProp>();
    public static Dictionary<string, Monster> AllMonsters = new Dictionary<string, Monster>();
    public static Dictionary<string, Status> AllStates = new Dictionary<string, Status>();
    public static Dictionary<string, List<string>> sceneMonstersDictionary = 
        new Dictionary<string, List<string>>();
    public static Dictionary<string, MountainInformation> Mountains = new Dictionary<string, MountainInformation>();
    public static Dictionary<string, string> mergeReflect = new Dictionary<string, string>();
    public static List<string> sceneMonsterNumber = new List<string>();
    public static Dictionary<string, bool> HasFightAreaBoss = new Dictionary<string, bool>();
    public static List<string> HasFightScenes = new List<string>();
    public static List<string> AllConversationList = new List<string>();
    public static List<string> HasFightBossScenes = new List<string>();
    public static Dictionary<string, Mission> AllMissions = new Dictionary<string, Mission>();
    public static List<Mission> ExistingMissions = new List<Mission>();
    public static List<Level> AllLevel = new List<Level>();
    public static Dictionary<string, Talent> AllTalent = new Dictionary<string, Talent>();
    public static List<Talent> ExistingTalent = new List<Talent>();
    public static Monster kraKen = new Monster("0", "", "kraken", 30, 15, 10, null, 1, "", "");
    public static string LeadName;
    public static Level Realm;
    public static string currentScene = "scene2";
    public static string preMap = null;
    public static readonly int MAX_NUMBER_OF_FIGHT_CARDS = 30; 
    public static bool Chance(int demarcationline)
    {
        int randomInt = Random.Range(1, 101);
        if (randomInt <= demarcationline)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static IEnumerator FadeLoadScene(string sceneName)
    {
        GameObject.Find("fade").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(sceneName);
    }
    public static void ClearGameData()
    {
        ExistingCards.Clear();
        FightCards.Clear();
        BattleItems.Clear();
        PlotItems.Clear();
        ExistingLeadSkills.Clear();
        System.Array.Clear(FightSkills, 0, FightSkills.Length);
        kraKen.DefensivePower = 15;
        kraKen.AttactPower = 30;
        kraKen.BloodVolume = 300;
        HasFightAreaBoss.Clear();
        HasFightBossScenes.Clear();
        HasFightScenes.Clear();
    }

    public static bool JudgeMission(bool isStart)
    {
        bool isLoadMission = false;
        foreach (string conversation in AllConversationList)
        {
            string[] numbers = conversation.Split('-');
            string part;
            if (isStart)
            {
                part = "0";
            }
            else
            {
                part = "1";
            }
            string missionScene = numbers[0] + "-" + numbers[1] + "-" + numbers[2] + "-" + numbers[3];
            if (numbers.Length > 4 &&
                missionScene.Equals(currentScene + "-"+part))
            {
                Mission currentMission = NumberInExisting(numbers[4]);
                if ((currentMission != null && currentMission.CurrentIndex + 1 == int.Parse(numbers[5])) ||
                    (currentMission == null && numbers[5].Equals("1")))
                {
                    string nextScene;
                    if (isStart)
                    {
                        nextScene = "mainLine";
                    }
                    else
                    {
                        nextScene = "tertiaryMap";
                    }
                    isLoadMission = true;
                    ++currentMission.CurrentIndex;
                    LoadConversation.SetConversation(currentScene, int.Parse(part), nextScene
                        , numbers[4] + "-" + numbers[5]);
                }
            }
        }
        return isLoadMission;
    }

    public static Mission NumberInExisting(string number)
    {
        foreach (Mission mission in ExistingMissions)
        {
            if (mission.SerialNumber.Equals(number))
            {
                return mission;
            }
        }
        return null;
    }

    public static void AfterFight()
    {
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
    }

    static bool HasBoss()
    {
        foreach (string number in GlobalVariable.sceneMonsterNumber)
        {
            if (number.StartsWith("2"))
            {
                return true;
            }
        }
        return false;
    }

    static bool HasAreaBoss()
    {
        List<string> areaBoss = new List<string> { "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008" };
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
