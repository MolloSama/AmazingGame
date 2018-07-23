using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGray : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (!GlobalVariable.HasFightAreaBoss.ContainsKey(GlobalVariable.preMap))
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
        }
	}
}
