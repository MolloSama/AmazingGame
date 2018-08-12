using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PanelControl : MonoBehaviour {
    public static bool open = false;
    public static GameObject openObject;
    public static int count;
    public static PanelControl _instance;
    public static bool clickable = true;

	// Use this for initialization
	void Start () {
        _instance = this;
	}

    private void OnMouseUpAsButton()
    {
        if (clickable)
        {
            clickable = false;
            if (open)
            {
                if (openObject.name.Equals(name))
                {
                    switch (name)
                    {
                        case "Backpack":
                            GameObject g1 = GameObject.Find("Backpack");
                            openObject.transform.DOMove(new Vector3(g1.transform.position.x, g1.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                clickable = true;
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
                            openObject.transform.DOMove(new Vector3(g2.transform.position.x, g2.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                clickable = true;
                            });
                            break;
                        case "SkillSelect":
                            SkillSelect.Clear();
                            GameObject g3 = GameObject.Find("SkillSelect");
                            openObject.transform.DOMove(new Vector3(g3.transform.position.x, g3.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                clickable = true;
                            });
                            break;
                        case "Merge":
                            MergeSelect.Clear();
                            GameObject g4 = GameObject.Find("Merge");
                            openObject.transform.DOMove(new Vector3(g4.transform.position.x, g4.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                clickable = true;
                            });
                            break;
                        case "Mission":
                            openObject.transform.DOMove(new Vector3(-7.22f, -2.91f), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                clickable = true;
                            });
                            break;
                        case "Map":
                            GameObject g6 = GameObject.Find("Map");
                            openObject.transform.DOMove(new Vector3(g6.transform.position.x, g6.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                clickable = true;
                            });
                            break;
                        default:
                            break;
                    }
                    open = false;
                    return;
                }
                else
                {
                    switch (openObject.name)
                    {
                        case "Backpack":
                            GameObject g1 = GameObject.Find("Backpack");
                            openObject.transform.DOMove(new Vector3(g1.transform.position.x, g1.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                AnOpen();
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
                            openObject.transform.DOMove(new Vector3(g2.transform.position.x, g2.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                AnOpen();
                            });
                            break;
                        case "SkillSelect":
                            SkillSelect.Clear();
                            GameObject g3 = GameObject.Find("SkillSelect");
                            openObject.transform.DOMove(new Vector3(g3.transform.position.x, g3.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                AnOpen();
                            });
                            break;
                        case "Merge":
                            MergeSelect.Clear();
                            GameObject g4 = GameObject.Find("Merge");
                            openObject.transform.DOMove(new Vector3(g4.transform.position.x, g4.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                AnOpen();
                            });
                            break;
                        case "Mission":
                            openObject.transform.DOMove(new Vector3(-7.22f, -2.91f), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                AnOpen();
                            });
                            break;
                        case "Map":
                            GameObject g6 = GameObject.Find("Map");
                            openObject.transform.DOMove(new Vector3(g6.transform.position.x, g6.transform.position.y), 0.2f);
                            openObject.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() =>
                            {
                                Destroy(openObject);
                                AnOpen();
                            });
                            break;
                        default:
                            break;
                    }
                    open = true;
                    return;
                }
            }
            if (!open)
            {
                AnOpen();
                open = true;
                return;
            }
        }
    }
    public static void Clear()
    {
        open = false;
        openObject = null;
    }
    public void OpenMap()
    {
        if (GlobalVariable.sceneflag == 3)
        {
            ThridMap.SetScene(GlobalVariable.middleMap);
            openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/ThridMap"), new Vector3(-7.22f, -4.15f, 0), Quaternion.identity);
            openObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
            openObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.3f).OnComplete(() => 
            {
                ThridMap._instance.AnShow();
                clickable = true;
            });
            openObject.name = "Map";
        }
        if (GlobalVariable.sceneflag == 2)
        {
            openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SecondMap" + GlobalVariable.middleMap.Split('-')[0]), new Vector3(-7.22f, -4.15f, 0), Quaternion.identity);
            openObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
            openObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.3f).OnComplete(() => clickable = true);
            openObject.name = "Map";
        }
        if (GlobalVariable.sceneflag == 1)
        {
            openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/FirstMap"), new Vector3(-7.22f, -4.15f, 0), Quaternion.identity);
            openObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
            openObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.3f).OnComplete(() => clickable = true);
            openObject.name = "Map";
        }
        open = true;
    }

    private void AnOpen()
    {
        switch (name)
        {
            case "Backpack":
                GameObject g1 = GameObject.Find("Backpack");
                openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/Backpack"), new Vector3(g1.transform.position.x, g1.transform.position.y, 0), Quaternion.identity);
                openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
                openObject.transform.DOScale(new Vector3(1, 1, 1), 0.3f).OnComplete(() => clickable = true);
                openObject.name = "Backpack";
                break;
            case "SelectCard":
                GameObject g2 = GameObject.Find("SelectCard");
                openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SelectCard"), new Vector3(g2.transform.position.x, g2.transform.position.y, 0), Quaternion.identity);
                openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
                openObject.transform.DOScale(new Vector3(1, 1, 1), 0.3f).OnComplete(() =>
                {
                    CardPanelManager._instance.AnShow();
                    clickable = true;
                });
                openObject.name = "SelectCard";
                break;
            case "SkillSelect":
                GameObject g3 = GameObject.Find("SkillSelect");
                openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SkillSelect"), new Vector3(g3.transform.position.x, g3.transform.position.y, 0), Quaternion.identity);
                openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
                openObject.transform.DOScale(new Vector3(1, 1, 1), 0.3f).OnComplete(() => clickable = true);
                openObject.name = "SkillSelect";
                break;
            case "Merge":
                GameObject g4 = GameObject.Find("Merge");
                openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/MergeCard"), new Vector3(g4.transform.position.x, g4.transform.position.y, 0), Quaternion.identity);
                openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
                openObject.transform.DOScale(new Vector3(1, 1, 1), 0.3f).OnComplete(() =>
                {
                    MergeManager._instance.AnShow();
                    clickable = true;
                });
                openObject.name = "Merge";
                break;
            case "Mission":
                GameObject g5 = GameObject.Find("Mission");
                openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/missionPane"), new Vector3(g5.transform.position.x, g5.transform.position.y, 0), Quaternion.identity);
                openObject.transform.DOMove(new Vector3(0, 0, 0), 0.3f);
                openObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.3f).OnComplete(() =>
                {
                    DisplayMissionTitle._instance.AnShow();
                    clickable = true;
                });
                openObject.name = "Mission";
                break;
            case "Map":
                OpenMap();
                break;
            default:
                break;
        }
    }
}
