using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMoney : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Find("moneyText").GetComponent<TextMesh>().text = GlobalVariable.money.ToString();
	}
}
