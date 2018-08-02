using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TalentIcon : MonoBehaviour {
    SpriteRenderer spr;
    public TextMesh talentText;
	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        switch (gameObject.name)
        {
            case "talent1":
                if(GlobalVariable.ExistingTalent.Count >= 1)
                {
                    spr.sprite = Resources.Load<Sprite>("talent/" + GlobalVariable.ExistingTalent[0].SerialNumber);
                }
                break;
            case "talent2":
                if (GlobalVariable.ExistingTalent.Count >= 2)
                {
                    spr.sprite = Resources.Load<Sprite>("talent/" + GlobalVariable.ExistingTalent[1].SerialNumber);
                }
                break;
            case "talent3":
                if (GlobalVariable.ExistingTalent.Count >= 3)
                {
                    spr.sprite = Resources.Load<Sprite>("talent/" + GlobalVariable.ExistingTalent[2].SerialNumber);
                }
                break;
            case "talent4":
                if (GlobalVariable.ExistingTalent.Count >= 4)
                {
                    spr.sprite = Resources.Load<Sprite>("talent/" + GlobalVariable.ExistingTalent[3].SerialNumber);
                }
                break;
        }
	}

    private void OnMouseEnter()
    {
        switch (gameObject.name)
        {
            case "talent1":
                if (GlobalVariable.ExistingTalent.Count >= 1)
                {
                    talentText.text = GlobalVariable.ExistingTalent[0].Name + ":\n" +
                        Regex.Replace(GlobalVariable.ExistingTalent[0].Description, @"\S{22}", "$0\r\n");
                }
                break;
            case "talent2":
                if (GlobalVariable.ExistingTalent.Count >= 2)
                {
                    talentText.text = GlobalVariable.ExistingTalent[1].Name + ":\n" +
                        Regex.Replace(GlobalVariable.ExistingTalent[1].Description, @"\S{22}", "$0\r\n");
                }
                break;
            case "talent3":
                if (GlobalVariable.ExistingTalent.Count >= 3)
                {
                    talentText.text = GlobalVariable.ExistingTalent[2].Name + ":\n" +
                        Regex.Replace(GlobalVariable.ExistingTalent[2].Description, @"\S{22}", "$0\r\n");
                }
                break;
            case "talent4":
                if (GlobalVariable.ExistingTalent.Count >= 4)
                {
                    talentText.text = GlobalVariable.ExistingTalent[3].Name+":\n" +
                        Regex.Replace(GlobalVariable.ExistingTalent[3].Description, @"\S{22}", "$0\r\n");
                }
                break;
        }
    }

    private void OnMouseExit()
    {
        talentText.text = "";
    }
}
