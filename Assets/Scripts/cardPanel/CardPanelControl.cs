using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPanelControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseUpAsButton()
    {
        if (name.Equals("prev"))
        {
            CardPanelManager._instance.PrevPage();
        }
        if (name.Equals("next"))
        {
            CardPanelManager._instance.NextPage();
        }
    }

}
