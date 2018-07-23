using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

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
            Inventory._instance.PrevPage();
        }
        if (name.Equals("change"))
        {
            Inventory._instance.SwitchPanel();
        }
        if (name.Equals("next"))
        {
            Inventory._instance.NextPage();
        }
    }
}
