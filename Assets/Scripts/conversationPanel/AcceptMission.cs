using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcceptMission : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        if (gameObject.name.Equals("yes"))
        {
            GlobalVariable.ExistingMissions.Add(GlobalVariable.AllMissions[LoadConversation.missionNumber]);
        }
        else
        {
            --GlobalVariable.AllMissions[LoadConversation.missionNumber].CurrentIndex;
        }
        switch (LoadConversation.nextScene)
        {
            case "mainLine":
                LoadConversation.SetConversation(GlobalVariable.currentScene, 0, "fighting", "");
                break;
            case "tertiaryMap":
                SceneManager.LoadScene("tertiaryMap");
                break;
        }
    }
}
