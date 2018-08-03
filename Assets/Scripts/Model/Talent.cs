using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Talent{

    public string SerialNumber { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Talent(string serialNumber, string name, string description)
    {
        SerialNumber = serialNumber;
        Name = name;
        Description = description;
    }
}
