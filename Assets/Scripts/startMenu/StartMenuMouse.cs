﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuMouse : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Mouse click
    public void OnMouseUpAsButton()
    {
        if (name.Equals("button1"))
        {
            SceneManager.LoadScene("setName");
        }
        if (name.Equals("button2"))
        {
            ReturnPre.preScene = "startMenu";
            SceneManager.LoadScene("accessProgress");
        }
        if (name.Equals("button3"))
        {

        }
    }
}
