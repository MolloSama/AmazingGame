using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPre : MonoBehaviour {
    public static string preScene;
	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        PanelControl.Clear();
        SceneManager.LoadScene(preScene);
    }
}
