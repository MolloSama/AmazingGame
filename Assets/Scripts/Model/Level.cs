using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Level{

    public float Edge { get; set; }

    public string Name { get; set; }

    public string Talent { get; set; }

    public Level(float edge, string name, string talent)
    {
        Edge = edge;
        Name = name;
        Talent = talent;
    }
}
