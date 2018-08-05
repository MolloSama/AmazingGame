using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGood : MonoBehaviour {

    public GameObject sellOut;
	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        int price = int.Parse(gameObject.transform.Find("price").GetComponent<TextMesh>().text);
        GameProp prop = StoreControl.reflect[gameObject];
        if (price <= GlobalVariable.money && prop != null)
        {
            if(prop.SerialNumber.Length == 5)
            {
                GlobalVariable.BattleItems.Add(prop);
                SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
                spr.material = Resources.Load<Material>("materials/SpriteGray");
                Instantiate(sellOut, transform.position, Quaternion.identity);
            }
            else
            {
                GlobalVariable.ExistingCards.Add(prop);
                SpriteRenderer cardRawImg = gameObject.transform.Find("card-raw-img").GetComponent<SpriteRenderer>();
                SpriteRenderer cardStyle = gameObject.transform.Find("card-style").GetComponent<SpriteRenderer>();
                cardRawImg.material = Resources.Load<Material>("materials/SpriteGray");
                cardStyle.material = Resources.Load<Material>("materials/SpriteGray");
                Instantiate(sellOut, transform.position + new Vector3(0.3f,0.5f,0), Quaternion.identity);
            }
            StoreControl.reflect[gameObject] = null;
            GlobalVariable.money -= price;
        }
    }
}
