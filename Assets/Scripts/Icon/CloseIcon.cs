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
                case "Merge":
                    MergeSelect.Clear();
                    Destroy(PanelControl.openObject);
                    break;
                case "Mission":
                    Destroy(PanelControl.openObject);
                    break;
                case "Map":
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
