using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
                    GameObject g1 = GameObject.Find("Backpack");
                    PanelControl.openObject.transform.DOMove(new Vector3(g1.transform.position.x,g1.transform.position.y), 0.2f);
                    PanelControl.openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                    {
                        Destroy(PanelControl.openObject);
                        PanelControl.clickable = true;
                    });
                    break;
                case "SelectCard":
                    GlobalVariable.FightCards.Clear();
                    GlobalVariable.FightCardsIndex.Clear();
                    for (int i = 0; i < CardSelect.count; i++)
                    {
                        GlobalVariable.FightCards.Add(GlobalVariable.fightCardsGrids[i].gameProp);
                        GlobalVariable.FightCardsIndex.Add(GlobalVariable.fightCardsGrids[i].index);
                    }
                    CardSelect.Clear();
                    BarScript.Clear();
                    GameObject g2 = GameObject.Find("SelectCard");
                    PanelControl.openObject.transform.DOMove(new Vector3(g2.transform.position.x, g2.transform.position.y), 0.2f);
                    PanelControl.openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                    {
                        Destroy(PanelControl.openObject);
                        PanelControl.clickable = true;
                    });
                    break;
                case "SkillSelect":
                    SkillSelect.Clear();
                    GameObject g3 = GameObject.Find("SkillSelect");
                    PanelControl.openObject.transform.DOMove(new Vector3(g3.transform.position.x, g3.transform.position.y), 0.2f);
                    PanelControl.openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                    {
                        Destroy(PanelControl.openObject);
                        PanelControl.clickable = true;
                    });
                    break;
                case "Merge":
                    MergeSelect.Clear();
                    GameObject g4 = GameObject.Find("Merge");
                    PanelControl.openObject.transform.DOMove(new Vector3(g4.transform.position.x, g4.transform.position.y), 0.2f);
                    PanelControl.openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                    {
                        Destroy(PanelControl.openObject);
                        PanelControl.clickable = true;
                    });
                    break;
                case "Mission":
                    GameObject g5 = GameObject.Find("Merge");
                    PanelControl.openObject.transform.DOMove(new Vector3(g5.transform.position.x, g5.transform.position.y), 0.2f);
                    PanelControl.openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                    {
                        Destroy(PanelControl.openObject);
                        PanelControl.clickable = true;
                    });
                    break;
                case "Map":
                    GameObject g6 = GameObject.Find("Map");
                    PanelControl.openObject.transform.DOMove(new Vector3(g6.transform.position.x, g6.transform.position.y), 0.2f);
                    PanelControl.openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                    {
                        Destroy(PanelControl.openObject);
                        PanelControl.clickable = true;
                    });
                    break;
                default:
                    break;
            }
            PanelControl.open = false;
            return;
        }
    }
}
