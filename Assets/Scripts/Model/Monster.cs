using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Monster{

    private float attactPower;

    public float defensivePower;

    public string SerialNumber { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public float AttactPower {
        get
        {
            return attactPower;
        }
        set
        {
            attactPower = float.Parse(Math.Round(value, 0).ToString());
        }
    }

    public float DefensivePower
    {
        get
        {
            return defensivePower;
        }
        set
        {
            defensivePower = float.Parse(Math.Round(value, 0).ToString());
        }
    }

    public int BloodVolume { get; set; }

    public List<GameProp> SkillList { get; set; }

    public int Attribute { get; set; }

    public string Description { get; set; }

    public string Animation { get; set; }

    public List<Status> StatusList { get; set; }

    public int StatusIndex { get; set; }

    public Dictionary<int, GameObject> StatusIndexReflect { get; set; }

    public Monster(String serialNumber, string code, string name, float attactPower, float defensivePower,
        int bloodVolume, List<GameProp> skillList, int attribute, string description, string animation)
    {
        SerialNumber = serialNumber;
        Code = code;
        Name = name;
        AttactPower = attactPower;
        DefensivePower = defensivePower;
        BloodVolume = bloodVolume;
        SkillList = skillList;
        Attribute = attribute;
        Description = description;
        Animation = animation;
        StatusList = new List<Status>();
        StatusIndex = -1;
        StatusIndexReflect = new Dictionary<int, GameObject>();
    }

    public Monster(string serialNumber)
    {
        SerialNumber = serialNumber;
    }
}
