using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameProp{
    public string SerialNumber { get; set; }

    public string Name { get; set; }

    public int EnergyConsumption { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public float Value { get; set; }

    public int ConsecutiveRounds { get; set; }

    public int Attribute { get; set; }

    public int TargetQuantity { get; set; }

    public string Animation { get; set; }

    public string StatusIcon { get; set; }

    public GameProp() { }

    public GameProp(string serialNumber, string name, int energyConsumption, string type,
        string description, float value, int consecutiveRounds, int attribute, int targetQuantity,
        string animation, string statusIcon)
    {
        SerialNumber = serialNumber;
        Name = name;
        EnergyConsumption = energyConsumption;
        Type = type;
        Description = description;
        Value = value;
        ConsecutiveRounds = consecutiveRounds;
        Attribute = attribute;
        TargetQuantity = targetQuantity;
        Animation = animation;
        StatusIcon = statusIcon;
    }
}
