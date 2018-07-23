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
        if (GlobalVariable.HasFightBossScenes.Contains(GlobalVariable.currentScene))
        {
            LoadConversation.SetConversation("0-9-0", 0, "tertiaryMap");
        }
        else
        {
            if (GlobalVariable.AllConversationList.Contains(GlobalVariable.currentScene + "-0") &&
                !GlobalVariable.HasFightScenes.Contains(GlobalVariable.currentScene))
            {
                LoadConversation.SetConversation(GlobalVariable.currentScene, 0, "fight");
            }
            else
            {
                SceneManager.LoadScene("fighting");
            }
            
        }
        
    }
}
