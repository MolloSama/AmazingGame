using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroupValue : MonoBehaviour {
    TextMesh textMesh;
    public GameControll gameControll;
	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        textMesh.text = gameControll.cardGroup.Count.ToString();
	}
}
