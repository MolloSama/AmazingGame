using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeUp : MonoBehaviour {

    public static bool isUp = false;
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
            Material material = Resources.Load<Material>("materials/SpriteGray");
            attack.GetComponent<SpriteRenderer>().material = material;
            defend.GetComponent<SpriteRenderer>().material = material;
            blood.GetComponent<SpriteRenderer>().material = material;
        }
    }
}
