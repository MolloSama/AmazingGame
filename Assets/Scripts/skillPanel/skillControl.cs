using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseUpAsButton()
    {

        if (name.Equals("reset"))
        {
            for (int i = 0; i < GlobalVariable.FightSkills.Length; i++)
            {
                if(GlobalVariable.FightSkills[i]!=null)
                    foreach (GameObject t in SkillSelect.skillOnGrid)
                    {
                        if(t!=null)
                            if (t.GetComponent<SkillSelect>().skill.SerialNumber.Equals(GlobalVariable.FightSkills[i].SerialNumber))
                            {
                                t.transform.Find("skill").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
                                break;
                            }
                    }
                GlobalVariable.FightSkills[i] = null;
            }
            GameObject.Find("skillgrid1").transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/base");
            GameObject.Find("skillgrid2").transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/base");
            GameObject.Find("skillgrid3").transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/base");
        }
    }
}
