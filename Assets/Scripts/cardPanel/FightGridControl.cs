using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightGridControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        if(name.Equals("next1"))
        {
            CardSelect._instance.NextPage();
        }
        if(name.Equals("prev1"))
        {
            CardSelect._instance.PrevPage();
        }
    }
}
