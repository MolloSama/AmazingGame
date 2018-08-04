using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ItemRender : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int chance = 20;
        if (GlobalVariable.HasFightScenes.Contains(GlobalVariable.currentScene))
        {
            chance = 0;
        }
        if (GlobalVariable.Chance(chance))
        {
            List<GameProp> allBattleItems = new List<GameProp>();
            foreach(GameProp item in GlobalVariable.AllGameItems.Values)
            {
                if (!item.Type.Equals("a4e17"))
                {
                    allBattleItems.Add(item);
                }
            }
            int randomIndex = Random.Range(0, allBattleItems.Count);
            GameProp randomItem = allBattleItems[randomIndex];
            GlobalVariable.BattleItems.Add(randomItem);
            Transform itemImg = transform.Find("itemImg");
            itemImg.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("item/" + randomItem.SerialNumber);
            Transform itemName = transform.Find("itemName");
            itemName.GetComponent<TextMesh>().text = randomItem.Name;
            Transform itemDescription = transform.Find("itemDescription");
            string description = randomItem.Description;
            itemDescription.GetComponent<TextMesh>().text = Regex.Replace(description, @"\S{13}", "$0\r\n");
            GlobalVariable.itemIllustration[randomItem] = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
