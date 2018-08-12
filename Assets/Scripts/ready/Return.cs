using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "returnMap":
                if (GlobalVariable.HasFightAreaBossScenes.Contains(GlobalVariable.topMap))
                {
                    gameObject.transform.parent.gameObject.SetActive(false);
                    GameObject temp = Instantiate(Resources.Load<GameObject>("PanelPrefabs/FirstMap"), new Vector3(0, 0, 0), Quaternion.identity);
                    temp.name = "Map";
                    PanelControl.openObject = temp;
                    Destroy(gameObject.transform.parent.gameObject);
                }
                break;
            case "returnToSecondary":
                if (!GlobalVariable.middleMap.StartsWith("1") ||  GlobalVariable.HasFightZSBossScenes.Contains(GlobalVariable.middleMap))
                {
                    GameObject current = gameObject.transform.parent.gameObject;
                    SecondMap.SetScene(GlobalVariable.middleMap.Split('-')[0]);
                    current.SetActive(false);
                    GameObject temp1 = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SecondMap" + GlobalVariable.middleMap.Split('-')[0]), new Vector3(0, 0, 0), Quaternion.identity);
                    temp1.name = "Map";
                    PanelControl.openObject = temp1;
                    Destroy(current);
                }
                break;
            case "cardPanelReturn":
                for (int i = 0; i < CardSelect.count; i++)
                {
                    GlobalVariable.FightCards.Add(GlobalVariable.fightCardsGrids[i].gameProp);
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
