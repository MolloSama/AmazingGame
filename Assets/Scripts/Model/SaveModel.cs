using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveModel{

    private List<GameProp> existCards;
    private List<GameProp> fightCards;
    private List<GameProp> battleItems;
    private List<GameProp> plotItems;
    private List<GameProp> existSkill;
    private GameProp[] fightSkill;
    private Monster kraken;
    private List<string> hasFightZSBossScenes;
    private List<string> hasFightScenes;
    private List<string> hasFightBossScenes;
    private List<string> hasFightAreaBossScenes;
    private string currentScenes;
    private string time;
    private string leadName;
    private Level realm;
    private List<Talent> existTalents;
    private List<Mission> existMissinos;
    private Dictionary<string, Mission> allMissions;
    private int money;
    private List<int> fightCardsIndex;
    private int sceneflag;

    public List<GameProp> ExistCards
    {
        get
        {
            return existCards;
        }

        set
        {
            existCards = value;
        }
    }

    public List<GameProp> FightCards
    {
        get
        {
            return fightCards;
        }

        set
        {
            fightCards = value;
        }
    }

    public List<GameProp> BattleItems
    {
        get
        {
            return battleItems;
        }

        set
        {
            battleItems = value;
        }
    }

    public List<GameProp> PlotItems
    {
        get
        {
            return plotItems;
        }

        set
        {
            plotItems = value;
        }
    }

    public List<GameProp> ExistSkill
    {
        get
        {
            return existSkill;
        }

        set
        {
            existSkill = value;
        }
    }

    public GameProp[] FightSkill
    {
        get
        {
            return fightSkill;
        }

        set
        {
            fightSkill = value;
        }
    }

    public Monster Kraken
    {
        get
        {
            return kraken;
        }

        set
        {
            kraken = value;
        }
    }

    public List<string> HasFightZSBossScenes
    {
        get
        {
            return hasFightZSBossScenes;
        }

        set
        {
            hasFightZSBossScenes = value;
        }
    }

    public List<string> HasFightScenes
    {
        get
        {
            return hasFightScenes;
        }

        set
        {
            hasFightScenes = value;
        }
    }

    public List<string> HasFightBossScenes
    {
        get
        {
            return hasFightBossScenes;
        }

        set
        {
            hasFightBossScenes = value;
        }
    }

    public string CurrentScenes
    {
        get
        {
            return currentScenes;
        }

        set
        {
            currentScenes = value;
        }
    }

    public string Time
    {
        get
        {
            return time;
        }

        set
        {
            time = value;
        }
    }

    public string LeadName
    {
        get
        {
            return leadName;
        }

        set
        {
            leadName = value;
        }
    }

    public List<Talent> ExistTalents
    {
        get
        {
            return existTalents;
        }

        set
        {
            existTalents = value;
        }
    }

    public List<Mission> ExistMissinos
    {
        get
        {
            return existMissinos;
        }

        set
        {
            existMissinos = value;
        }
    }

    public Level Realm
    {
        get
        {
            return realm;
        }

        set
        {
            realm = value;
        }
    }

    public int Money
    {
        get
        {
            return money;
        }

        set
        {
            money = value;
        }
    }

    public List<int> FightCardsIndex
    {
        get
        {
            return fightCardsIndex;
        }

        set
        {
            fightCardsIndex = value;
        }
    }

    public int Sceneflag
    {
        get
        {
            return sceneflag;
        }

        set
        {
            sceneflag = value;
        }
    }

    public Dictionary<string, Mission> AllMissions
    {
        get
        {
            return allMissions;
        }

        set
        {
            allMissions = value;
        }
    }

    public List<string> HasFightAreaBossScenes
    {
        get
        {
            return hasFightAreaBossScenes;
        }

        set
        {
            hasFightAreaBossScenes = value;
        }
    }

    public SaveModel()
    {
        existCards = GlobalVariable.ExistingCards;
        fightCards = GlobalVariable.FightCards;
        existSkill = GlobalVariable.ExistingLeadSkills;
        fightSkill = GlobalVariable.FightSkills;
        battleItems = GlobalVariable.BattleItems;
        plotItems = GlobalVariable.PlotItems;
        kraken = GlobalVariable.kraKen;
        hasFightZSBossScenes = GlobalVariable.HasFightZSBossScenes;
        hasFightBossScenes = GlobalVariable.HasFightBossScenes;
        hasFightScenes = GlobalVariable.HasFightScenes;
        hasFightAreaBossScenes = GlobalVariable.HasFightAreaBossScenes;
        currentScenes = GlobalVariable.currentScene;
        time = DateTime.Now.ToString();
        leadName = GlobalVariable.LeadName;
        realm = GlobalVariable.Realm;
        existTalents = GlobalVariable.ExistingTalent;
        existMissinos = GlobalVariable.ExistingMissions;
        allMissions = GlobalVariable.AllMissions;
        money = GlobalVariable.money;
        fightCardsIndex = GlobalVariable.FightCardsIndex;
        sceneflag = GlobalVariable.sceneflag;
    }
}
