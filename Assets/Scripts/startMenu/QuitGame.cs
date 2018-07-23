using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        Application.Quit();
    }
}
