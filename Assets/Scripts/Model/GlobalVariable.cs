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
    public static Monster kraKen = new Monster("0","","kraken",30, 15, 10, null, 1, "","");
    public static List<string> sceneMonsterNumber = new List<string>();
    public static Dictionary<string, bool> HasFightAreaBoss = new Dictionary<string, bool>();
    public static List<string> HasFightScenes = new List<string>();
    public static List<string> AllConversationList = new List<string>();
    public static List<string> HasFightBossScenes = new List<string>();
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

}
