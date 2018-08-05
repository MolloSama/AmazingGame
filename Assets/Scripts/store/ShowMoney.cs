using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoney : MonoBehaviour {

    TextMesh textMesh;
	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();

    }

    private void Update()
    {
        textMesh.text = GlobalVariable.money.ToString();
    }
}
