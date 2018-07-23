using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondarySelect : MonoBehaviour {

    private static string sceneName;

    public static bool setOver = false;

    // Use this for initialization
    void Start () {
        setOver = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetScene(string temp)
    {
        sceneName = temp;
        setOver = true;
    }

    public void OnMouseUpAsButton()
    {
        if (sceneName == null)
        {
            sceneName = GlobalVariable.preMap.Split('-')[0];
        }
        TertiaryMapSelect.SetScene(sceneName + '-' + gameObject.name);
        while (true)
        {
            if (!TertiaryMapSelect.setOver)
                continue;
            else
            {
                SceneManager.LoadScene("tertiaryMap");
                break;
            }
        }
    }
}
