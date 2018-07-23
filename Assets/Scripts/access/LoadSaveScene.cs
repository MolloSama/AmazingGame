using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSaveScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        ReturnPre.preScene = "tertiaryMap";
        SceneManager.LoadScene("accessProgress");
    }
}
