using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Status{

    public int SerialNumber { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public float Value { get; set; }

    public int ResidueRounds { get; set; }

    public int Index { get; set; }

    public Status(int serialNumber, string code, string name, 
        float value, int residueRounds)
    {
        SerialNumber = serialNumber;
        Code = code;
        Name = name;
        Value = value;
        ResidueRounds = residueRounds;
    }
}
