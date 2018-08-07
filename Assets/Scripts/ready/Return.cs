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
            case "returnMap":
                GlobalVariable.sceneflag = 1;
                gameObject.transform.parent.gameObject.SetActive(false);
                GameObject temp = Instantiate(Resources.Load<GameObject>("PanelPrefabs/FirstMap"), new Vector3(0, 0, 0), Quaternion.identity);
                temp.name = "Map";
                PanelControl.openObject = temp;
                Destroy(gameObject.transform.parent.gameObject);
                //SceneManager.LoadScene("mainMap");
                break;
            case "returnToSecondary":
                GlobalVariable.sceneflag = 2;
                if (GlobalVariable.HasFightAreaBoss.ContainsKey(GlobalVariable.preMap))
                {
                    GameObject current = gameObject.transform.parent.gameObject;
                    SecondMap.SetScene(GlobalVariable.preMap.Split('-')[0]);
                    current.SetActive(false);
                    GameObject temp1 = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SecondMap"), new Vector3(0, 0, 0), Quaternion.identity);
                    temp1.name = "Map";
                    PanelControl.openObject = temp1;
                    string[] mapNumber = GlobalVariable.currentScene.Split('-');
                    GlobalVariable.preMap = mapNumber[0] + "-" + mapNumber[1];
                    Destroy(current);
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
