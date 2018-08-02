using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeUp : MonoBehaviour {

    public static bool isUp = false;
    public static bool isLevelUp = false;
    public static bool isGetTalent = false;
    public GameObject attack;
    public GameObject defend;
    public GameObject blood;
    // Use this for initialization
    void Start()
    {
        if (GlobalVariable.HasFightScenes.Contains(GlobalVariable.currentScene))
        {
            isUp = true;
            Material material = Resources.Load<Material>("materials/SpriteGray");
            attack.GetComponent<SpriteRenderer>().material = material;
            defend.GetComponent<SpriteRenderer>().material = material;
            blood.GetComponent<SpriteRenderer>().material = material;
        }
    }

    private void OnMouseDown()
    {
        if (!isUp)
        {
            int randomPercent = Random.Range(5, 11);
            switch (gameObject.name)
            {
                case "attackUp":
                    GlobalVariable.kraKen.AttactPower *= (1 + randomPercent / 100f);
                    break;
                case "defendUp":
                    GlobalVariable.kraKen.DefensivePower *= (1 + randomPercent / 100f);
                    break;
                case "bloodUp":
                    GlobalVariable.kraKen.BloodVolume += 
                        System.Convert.ToInt32(GlobalVariable.kraKen.BloodVolume*(randomPercent / 100f));
                    break;
            }
            isUp = true;
            UpLevel();
            Material material = Resources.Load<Material>("materials/SpriteGray");
            attack.GetComponent<SpriteRenderer>().material = material;
            defend.GetComponent<SpriteRenderer>().material = material;
            blood.GetComponent<SpriteRenderer>().material = material;
        }
    }

    void UpLevel()
    {
        isLevelUp = false;
        isGetTalent = false;
        float currentLevel = GlobalVariable.kraKen.AttactPower + GlobalVariable.kraKen.DefensivePower * 2 + GlobalVariable.kraKen.BloodVolume * 0.1f;
        foreach(Level level in GlobalVariable.AllLevel)
        {
            if(currentLevel >= level.Edge && level.Edge > GlobalVariable.Realm.Edge)
            {
                GlobalVariable.Realm = level;
                if (!level.Talent.Equals(""))
                {
                    GlobalVariable.ExistingTalent.Add(GlobalVariable.AllTalent[level.Talent]);
                    isGetTalent = true;
                }
                isLevelUp = true;
            }
        }
    }
}
