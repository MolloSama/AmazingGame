using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridReturnGray : MonoBehaviour {

    // Update is called once per frame
    void Start()
    {
        if (!GlobalVariable.middleMap.StartsWith("1") || GlobalVariable.HasFightZSBossScenes.Contains(GlobalVariable.middleMap))
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default"); 
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
        }
    }
}