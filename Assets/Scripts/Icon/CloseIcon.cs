using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseIcon : MonoBehaviour {
    public static int count;

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseUpAsButton()
    {
        if (PanelControl.open)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "mainMap":
                    GameObject.Find("1").GetComponent<BoxCollider2D>().enabled = true;
                    break;
                case "secondaryMap":
                    GameObject.Find("1").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("2").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("3").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("4").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("5").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("6").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("7").GetComponent<BoxCollider2D>().enabled = true;
                    GameObject.Find("8").GetComponent<BoxCollider2D>().enabled = true;
                    break;
                case "tertiaryMap":
                    for (int i = 1; i < count + 1; i++)
                    {
                        GameObject.Find(i.ToString()).GetComponent<BoxCollider>().enabled = true;
                    }
                    break;
                default:
                    break;
            }
            switch (PanelControl.openObject.name)
            {
                case "Backpack":
                    Destroy(PanelControl.openObject);
                    break;
                case "SelectCard":
                    GlobalVariable.FightCards.Clear();
                    GlobalVariable.FightCardsIndex.Clear();
                    for (int i = 0; i < CardSelect.count; i++)
                    {
                        GlobalVariable.FightCards.Add(CardSelect.fightCardsGrids[i].gameProp);
                        GlobalVariable.FightCardsIndex.Add(CardSelect.fightCardsGrids[i].index);
                    }
                    CardSelect.Clear();
                    BarScript.Clear();
                    Destroy(PanelControl.openObject);
                    break;
                case "SkillSelect":
                    SkillSelect.Clear();
                    Destroy(PanelControl.openObject);
                    break;
                default:
                    break;
            }
            PanelControl.open = false;
            return;
        }
    }
}
