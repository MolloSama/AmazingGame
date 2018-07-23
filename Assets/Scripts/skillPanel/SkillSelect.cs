using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SkillSelect : MonoBehaviour {

    public GameProp skill = null;

    public static List<GameObject> skillOnGrid = new List<GameObject>();

    public static string currentSkillGrid = null;

    public static void Clear()
    {
        for(int i = 0; i < skillOnGrid.Count; i++)
        {
            skillOnGrid[i] = null;
        }
        currentSkillGrid = null;
    }

	// Use this for initialization
	void Start () {

	}

    public void SetSkill(GameProp prop)
    {
        skill = prop;
        if (skill != null)
        {
            transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("skill/" + skill.SerialNumber);
            skillOnGrid.Add(gameObject);
            foreach(GameProp t in GlobalVariable.FightSkills)
            {
                if (t != null && t.SerialNumber.Equals(skill.SerialNumber))
                {
                    transform.Find("skill").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                }
            }
        }
        else
            transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/base");
    }

    private void OnMouseUpAsButton()
    {
        if (currentSkillGrid != null)
        {
            if (skill != null)
            {
                foreach(GameProp t in GlobalVariable.FightSkills)
                {
                    if (t != null && t.SerialNumber.Equals(skill.SerialNumber))
                        return;
                }
                int index = -1;
                switch (currentSkillGrid)
                {
                    case "skillgrid1":
                        index = 0;
                        break;
                    case "skillgrid2":
                        index = 1;
                        break;
                    case "skillgrid3":
                        index = 2;
                        break;
                    default:
                        break;
                }
                if (index != -1)
                {
                    if (GlobalVariable.FightSkills[index] != null)
                        foreach (GameObject t in skillOnGrid)
                        {
                            if (t.GetComponent<SkillSelect>().skill.SerialNumber.Equals(GlobalVariable.FightSkills[index].SerialNumber))
                            {
                                t.transform.Find("skill").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
                                break;
                            }
                        }
                    GlobalVariable.FightSkills[index] = skill;
                }
                transform.Find("skill").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                GameObject temp = GameObject.Find(currentSkillGrid);
                temp.transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("skill/{0}", skill.SerialNumber));
            }
        }
    }
    private void OnMouseEnter()
    {
        if (skill != null)
        {
            string text = Regex.Replace(skill.Description, @"\S{16}", "$0\r\n");
            GameObject.Find("skillinfo").GetComponent<TextMesh>().text = "技能介绍：\n" + text;
        }
    }
    private void OnMouseExit()
    {
        GameObject.Find("skillinfo").GetComponent<TextMesh>().text = "";
    }
}
