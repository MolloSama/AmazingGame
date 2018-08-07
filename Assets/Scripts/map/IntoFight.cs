using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntoFight : MonoBehaviour {

    public MountainInformation mountainInformation;

    public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
    private void OnMouseUpAsButton()
    {
        GlobalVariable.currentScene = mountainInformation.serialnumber;
        if (GlobalVariable.StoreScenes.Contains(GlobalVariable.currentScene) && GlobalVariable.Chance(30))
        {
            SceneManager.LoadScene("store");
        }
        else
        {
            if (!GlobalVariable.JudgeMission(true))
            {
                GlobalVariable.BeforeFight();
            }
        }
    }
}
