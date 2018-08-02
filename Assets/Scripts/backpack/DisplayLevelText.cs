using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLevelText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = GlobalVariable.Realm.Name;
	}
}
