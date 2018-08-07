using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSaveScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PanelControl._instance.OpenMap();
	}

    private void OnMouseDown()
    {
        ReturnPre.preScene = "ready";
        SceneManager.LoadScene("accessProgress");
    }
}
