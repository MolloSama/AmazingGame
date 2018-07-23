using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenValue : MonoBehaviour {

    public GameControll gameControll;
    TextMesh text;
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameObject.name)
        {
            case "health-text":
                text.text = gameControll.kraken.BloodVolume.ToString();
                break;
            case "attack-text":
                text.text = gameControll.kraken.AttactPower.ToString();
                break;
            case "defend-text":
                text.text = gameControll.kraken.DefensivePower.ToString();
                break;
        }
	}
}
