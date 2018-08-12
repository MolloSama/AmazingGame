using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondReturnGray : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!GlobalVariable.HasFightAreaBossScenes.Contains(GlobalVariable.topMap))
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
        }
    }
}
