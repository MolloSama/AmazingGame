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
    private Dictionary<string, bool> hasFightAreaBoss;
    private List<string> hasFightScenes;
    private List<string> hasFightBossScenes;
    private string currentScenes;
    private string time;
    private string leadName;
    private List<Talent> existTalents;
    private List<Mission> existMissinos;

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

    public Dictionary<string, bool> HasFightAreaBoss
    {
        get
        {
            return hasFightAreaBoss;
        }

        set
        {
            hasFightAreaBoss = value;
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

    public SaveModel()
    {
        existCards = GlobalVariable.ExistingCards;
        fightCards = GlobalVariable.FightCards;
        existSkill = GlobalVariable.ExistingLeadSkills;
        fightSkill = GlobalVariable.FightSkills;
        battleItems = GlobalVariable.BattleItems;
        plotItems = GlobalVariable.PlotItems;
        kraken = GlobalVariable.kraKen;
        hasFightAreaBoss = GlobalVariable.HasFightAreaBoss;
        hasFightBossScenes = GlobalVariable.HasFightBossScenes;
        hasFightScenes = GlobalVariable.HasFightScenes;
        currentScenes = GlobalVariable.currentScene;
        time = DateTime.Now.ToString();
        leadName = GlobalVariable.LeadName;
        existTalents = GlobalVariable.ExistingTalent;
        existMissinos = GlobalVariable.ExistingMissions;
    }
}
