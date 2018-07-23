using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using DG.Tweening;

public class PlaySkill : MonoBehaviour {

    private SpriteRenderer spr;
    private bool isUseSkill = false;
    public GameControll gameControll;
    public GameObject skillPane;
    private TextMesh skillName;
    private TextMesh skillDescription;
    private SpriteRenderer skillIcon;
    private GameObject skill;
    public GameObject monster4;
    public GameObject monster3;
    private Material material4;
    private Material material3;
    public GameObject leadSprite;

	// Use this for initialization
	void Start () {
        material3 = monster3.GetComponent<SpriteRenderer>().material;
        material4 = monster4.GetComponent<SpriteRenderer>().material;
        spr = gameObject.GetComponent<SpriteRenderer>();
        switch (gameObject.name)
        {
            case "skill1":
                if(GlobalVariable.FightSkills[0] != null)
                    spr.sprite = Resources.Load<Sprite>("skill/" + GlobalVariable.FightSkills[0].SerialNumber);
                break;
            case "skill2":
                if (GlobalVariable.FightSkills[1] != null)
                    spr.sprite = Resources.Load<Sprite>("skill/" + GlobalVariable.FightSkills[1].SerialNumber);
                break;
            case "skill3":
                if (GlobalVariable.FightSkills[2] != null)
                    spr.sprite = Resources.Load<Sprite>("skill/" + GlobalVariable.FightSkills[2].SerialNumber);
                break;
        }
    }

    private void OnMouseEnter()
    {
        
        switch (gameObject.name)
        {
            case "skill1":
                if (GlobalVariable.FightSkills[0] != null)
                {
                    LoadSkill(GlobalVariable.FightSkills[0]);
                }
                break;
            case "skill2":
                if (GlobalVariable.FightSkills[1] != null)
                {
                    LoadSkill(GlobalVariable.FightSkills[1]);
                }  
                break;
            case "skill3":
                if (GlobalVariable.FightSkills[2] != null)
                {
                    LoadSkill(GlobalVariable.FightSkills[2]);
                }
                break;
        }
    }

    void setMonsterHide()
    {
        if (monster4 != null)
        {
            SpriteRenderer monster4Spr = monster4.GetComponent<SpriteRenderer>();
            material4 = monster4Spr.material;
            Material defaultMaterial = new Material(Shader.Find("Sprites/Default"));
            monster4Spr.material = defaultMaterial;
        }
        if (monster3 != null)
        {
            SpriteRenderer monster3Spr = monster3.GetComponent<SpriteRenderer>();
            material3 = monster3Spr.material;
            Material defaultMaterial = new Material(Shader.Find("Sprites/Default"));
            monster3Spr.material = defaultMaterial;
        }
    }

    private void OnMouseExit()
    {
        if(monster4 != null)
        {
            SpriteRenderer monster4Spr = monster4.GetComponent<SpriteRenderer>();
            monster4Spr.material = material4;
        }
        if (monster3 != null)
        {
            SpriteRenderer monster3Spr = monster3.GetComponent<SpriteRenderer>();
            monster3Spr.material = material3;
        }
        if(skill != null)
        {
            Destroy(skill);
        }
    }


    void LoadSkill(GameProp skillProp)
    {
        setMonsterHide();
        skill = Instantiate(skillPane, transform.position + new Vector3(-1f, 1.5f, 0), Quaternion.identity);
        skillName = skill.transform.Find("skill-name").GetComponent<TextMesh>();
        skillDescription = skill.transform.Find("skill-description").GetComponent<TextMesh>();
        skillIcon = skill.transform.Find("skill-icon").GetComponent<SpriteRenderer>();
        skillName.text = skillProp.Name;
        skillDescription.text = Regex.Replace(skillProp.Description, @"\S{8}", "$0\r\n");
        skillIcon.sprite = Resources.Load<Sprite>("skill/" + skillProp.SerialNumber);
    }

    private void OnMouseDown()
    {
        if (!isUseSkill)
        {
            Material material = Resources.Load<Material>("materials/SpriteGray");
            spr.material = material;
            isUseSkill = true;
            switch (gameObject.name)
            {
                case "skill1":
                    if (GlobalVariable.FightSkills[0] != null)
                    {
                        StartCoroutine(MoveLead());
                        gameControll.KrakenRound(GlobalVariable.FightSkills[0]);
                    }
                    break;
                case "skill2":
                    if (GlobalVariable.FightSkills[1] != null)
                    {
                        StartCoroutine(MoveLead());
                        gameControll.KrakenRound(GlobalVariable.FightSkills[1]);
                    }
                    break;
                case "skill3":
                    if (GlobalVariable.FightSkills[2] != null)
                    {
                        StartCoroutine(MoveLead());
                        gameControll.KrakenRound(GlobalVariable.FightSkills[2]);
                    }
                    break;
            }
        }       
    }

    IEnumerator MoveLead()
    {
        Vector3 startPosition = leadSprite.transform.position;
        leadSprite.transform.DOMove(leadSprite.transform.position+new Vector3(-1.5f,0,0), 0.5f);
        yield return new WaitForSeconds(0.7f);
        leadSprite.transform.DOMove(startPosition, 0.5f);
    }
}
