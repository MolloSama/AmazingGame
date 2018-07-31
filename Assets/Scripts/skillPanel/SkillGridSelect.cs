using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGridSelect : MonoBehaviour {
    public GameProp gameProp;
	// Use this for initialization
	void Start () {
    }

    private void OnMouseUpAsButton()
    {
        if(gameProp!=null)
        {
            foreach(GameObject t in SkillSelect.skillOnGrid)
            {
                if (t != null)
                {
                    if (t.GetComponent<SkillSelect>().skill.SerialNumber.Equals(gameProp.SerialNumber))
                    {
                        t.transform.Find("skill").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
                        break;
                    }
                }
            }
            gameProp = null;
        }
        switch (gameObject.name)
        {
            case "skillgrid1":
                GlobalVariable.FightSkills[0] = null;
                break;
            case "skillgrid2":
                GlobalVariable.FightSkills[1] = null;
                break;
            case "skillgrid3":
                GlobalVariable.FightSkills[2] = null;
                break;
            default:
                break;
        }
        gameObject.transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/base");
    }
}
