using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseUpAsButton()
    {
        if (name.Equals("prev"))
        {
            MergeManager._instance.PrevPage();
        }
        if(name.Equals("next"))
        {
            MergeManager._instance.NextPage();
        }
    }
}
