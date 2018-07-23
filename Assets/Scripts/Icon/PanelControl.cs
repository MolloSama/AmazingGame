using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour {
    public static bool open = false;
    public static GameObject openObject;
    public static int count;

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseUpAsButton()
    {
        if (open)
        {
            if (openObject.name.Equals(name))
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
                switch (name)
                {
                    case "Backpack":
                        Destroy(openObject);
                        break;
                    case "SelectCard":
                        GlobalVariable.FightCards.Clear();

                        for (int i = 0; i < CardSelect.count; i++)
                        {
                            GlobalVariable.FightCards.Add(CardSelect.fightCardsGrids[i].gameProp);
                        }
                        CardSelect.Clear();
                        BarScript.Clear();
                        Destroy(openObject);
                        break;
                    case "SkillSelect":
                        SkillSelect.Clear();
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
                        for (int i = 0; i < CardSelect.count; i++)
                        {
                            GlobalVariable.FightCards.Add(CardSelect.fightCardsGrids[i].gameProp);
                        }
                        CardSelect.Clear();
                        BarScript.Clear();
                        Destroy(openObject);
                        break;
                    case "SkillSelect":
                        SkillSelect.Clear();
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
                    default:
                        break;
                }
                open = true;
                return;
            }
        }
        if (!open)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "mainMap":
                    GameObject.Find("1").GetComponent<BoxCollider2D>().enabled = false;
                    break;
                case "secondaryMap":
                    GameObject.Find("1").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("2").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("3").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("4").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("5").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("6").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("7").GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("8").GetComponent<BoxCollider2D>().enabled = false;
                    break;
                case "tertiaryMap":
                    for (int i = 1; i < count + 1; i++) 
                    {
                        GameObject.Find(i.ToString()).GetComponent<BoxCollider>().enabled = false;
                    }
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
}
