using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadySelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "backPack":
                SceneManager.LoadScene("backpack");
                break;
            case "skillPane":
                SceneManager.LoadScene("skillSelect");
                break;
            case "cardPane":
                SceneManager.LoadScene("selectCard");
                break;
            case "map":
                SceneManager.LoadScene("mainMap");
                break;
        }
    }
}
