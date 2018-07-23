using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCondition{

	public int ExtendsRounds { get; set; }

    public float KillPromote { get; set; }

    public float BloodSucking { get; set; }

    public List<GameProp> FullBloodItems { get; set; }

    public GameProp Revive { get; set; }

    public ItemCondition()
    {
        ExtendsRounds = 0;
        KillPromote = 0;
        BloodSucking = 0;
        FullBloodItems = new List<GameProp>();
        Revive = null;
    }
}
