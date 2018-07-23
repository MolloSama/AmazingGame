using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGridSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Find("frame").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
    }

    private void OnMouseUpAsButton()
    {
        transform.Find("frame").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/RedFrame");
        if (SkillSelect.currentSkillGrid != null)
            GameObject.Find(SkillSelect.currentSkillGrid).transform.Find("frame").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
        SkillSelect.currentSkillGrid = name;
    }
}
