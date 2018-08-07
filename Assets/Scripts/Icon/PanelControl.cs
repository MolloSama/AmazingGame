using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour {
    public static bool open = false;
    public static GameObject openObject;
    public static int count;
    public static PanelControl _instance;


	// Use this for initialization
	void Start () {
        _instance = this;
	}

    private void OnMouseUpAsButton()
    {
        if (open)
        {
            

            if (openObject.name.Equals(name))
            {
                switch (name)
                {
                    case "Backpack":
                        Destroy(openObject);
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
                        Destroy(openObject);
                        break;
                    case "SkillSelect":
                        SkillSelect.Clear();
                        Destroy(openObject);
                        break;
                    case "Merge":
                        MergeSelect.Clear();
                        Destroy(openObject);
                        break;
                    case "Map":
                        Destroy(openObject);
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
                        Destroy(openObject);
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
                        Destroy(openObject);
                        break;
                    case "SkillSelect":
                        SkillSelect.Clear();
                        Destroy(openObject);
                        break;
                    case "Merge":
                        MergeSelect.Clear();
                        Destroy(openObject);
                        break;
                    case "Map":
                        Destroy(openObject);
                        break;
                    default:
                        break;
                }
                switch (name)
                {
                    case "Backpack":
                        openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/Backpack"), new Vector3(0, 0, 0), Quaternion.identity);
                        openObject.name = "Backpack";
                        break;
                    case "SelectCard":
                        openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SelectCard"), new Vector3(0, 0, 0), Quaternion.identity);
                        openObject.name = "SelectCard";
                        break;
                    case "SkillSelect":
                        openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SkillSelect"), new Vector3(0, 0, 0), Quaternion.identity);
                        openObject.name = "SkillSelect";
                        break;
                    case "Merge":
                        openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/MergeCard"), new Vector3(0, 0, 0), Quaternion.identity);
                        openObject.name = "Merge";
                        break;
                    case "Map":
                        OpenMap();
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
            switch (name)
            {
                case "Backpack":
                    openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/Backpack"), new Vector3(0, 0, 0), Quaternion.identity);
                    openObject.name = "Backpack";
                    break;
                case "SelectCard":
                    openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SelectCard"), new Vector3(0, 0, 0), Quaternion.identity);
                    openObject.name = "SelectCard";
                    break;
                case "SkillSelect":
                    openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SkillSelect"), new Vector3(0, 0, 0), Quaternion.identity);
                    openObject.name = "SkillSelect";
                    break;
                case "Merge":
                    openObject=Instantiate(Resources.Load<GameObject>("PanelPrefabs/MergeCard"), new Vector3(0, 0, 0), Quaternion.identity);
                    openObject.name = "Merge";
                    break;
                case "Map":
                    OpenMap();
                    break;
                default:
                    break;
            }
            open = true;
            return;
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
            ThridMap.SetScene(GlobalVariable.preMap);
            openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/ThridMap"), new Vector3(0, 0, 0), Quaternion.identity);
            openObject.name = "Map";
        }
        if (GlobalVariable.sceneflag == 2)
        {
            //ThridMap.SetScene(GlobalVariable.preMap);
            openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SecondMap"), new Vector3(0, 0, 0), Quaternion.identity);
            openObject.name = "Map";
        }
        if (GlobalVariable.sceneflag == 1)
        {
            //ThridMap.SetScene(GlobalVariable.preMap);
            openObject = Instantiate(Resources.Load<GameObject>("PanelPrefabs/FirstMap"), new Vector3(0, 0, 0), Quaternion.identity);
            openObject.name = "Map";
        }
        open = true;
    }
}
