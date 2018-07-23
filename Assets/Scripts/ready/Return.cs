using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "return":
                SceneManager.LoadScene("ready");
                break;
            case "returnMap":
                SceneManager.LoadScene("mainMap");
                break;
            case "returnToSecondary":
                if (GlobalVariable.HasFightAreaBoss.ContainsKey(GlobalVariable.preMap))
                {
                    SceneManager.LoadScene("secondaryMap");
                }
                break;
            case "cardPanelReturn":
                for (int i = 0; i < CardSelect.count; i++)
                {
                    GlobalVariable.FightCards.Add(CardSelect.fightCardsGrids[i].gameProp);
                }
                break;
            case "backpackReturn":
                break;
            case "skillSelectReturn":
                break;
            default:
                break;
        }
    }
}
