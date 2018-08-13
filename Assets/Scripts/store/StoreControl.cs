﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class StoreControl : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject itemPrefab;
    public static Dictionary<GameObject, GameProp> reflect = new Dictionary<GameObject, GameProp>();
    private Dictionary<TextMesh, int> allPrice = new Dictionary<TextMesh, int>();

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 5; ++i)
        {
            GameObject cardObject = Instantiate(cardPrefab, cardPrefab.transform.position + 
                new Vector3(i * 2.4f, 0, 0), Quaternion.identity);
            List<string> cardProps = new List<string>(GlobalVariable.AllCards.Keys);
            RemoveCallCard(cardProps);
            int randomIndex = Random.Range(0, cardProps.Count);
            GameProp cardProp = GlobalVariable.AllCards[cardProps[randomIndex]];
            reflect.Add(cardObject, cardProp);
            DisplayCard(cardProp, cardObject);
        }
        List<GameProp> battleItems = new List<GameProp>();
        foreach(GameProp item in GlobalVariable.AllGameItems.Values)
        {
            if (!item.Type.Equals("a4e17"))
            {
                battleItems.Add(item);
            }
        }
        for(int i = 0; i < 3; ++i)
        {
            GameObject itemObject = Instantiate(itemPrefab, itemPrefab.transform.position + 
                new Vector3(i * 2.4f, 0, 0), Quaternion.identity);
            int randomIndex = Random.Range(0, battleItems.Count);
            GameProp itemProp = battleItems[randomIndex];
            reflect.Add(itemObject, itemProp);
            DisplayItem(itemProp, itemObject);
        }
	}

    private void Update()
    {
        foreach(TextMesh textMesh in allPrice.Keys)
        {
            if(allPrice[textMesh] > GlobalVariable.money)
            {
                textMesh.color = Color.red;
            }
        }
    }

    void DisplayCard(GameProp cardData, GameObject cardObject)
    {
        Transform skillText = cardObject.transform.Find("skill-text");
        string description = cardData.Description;
        skillText.GetComponent<TextMesh>().text = Regex.Replace(description, @"\S{8}", "$0\r\n");
        SpriteRenderer cardStyle = cardObject.transform.Find("card-style").GetComponent<SpriteRenderer>();
        Sprite style = Resources.Load<Sprite>("cardStyle/" +
            cardData.Type.Substring(0, 2) + cardData.EnergyConsumption);
        cardStyle.sprite = style;
        Transform cardName = cardObject.transform.Find("card-name");
        cardName.GetComponent<TextMesh>().text = cardData.Name;
        SpriteRenderer cardRawImg = cardObject.transform.Find("card-raw-img").GetComponent<SpriteRenderer>();
        Sprite rawImg = Resources.Load<Sprite>("cardRawImg/" + cardData.SerialNumber);
        cardRawImg.sprite = rawImg;
        TextMesh textMesh = cardObject.transform.Find("price").GetComponent<TextMesh>();
        int price = GetPrice("card");
        allPrice.Add(textMesh, price);
        textMesh.text = price.ToString();
            
    }

    void RemoveCallCard(List<string> list)
    {
        List<string> removeList = new List<string>();
        for (int i = 0; i < list.Count; ++i)
        {
            int number = int.Parse(list[i]);
            if (number >= 22 && number <= 32)
            {
                removeList.Add(list[i]);
            }
        }
        for (int i = 0; i < list.Count; ++i)
        {
            foreach (string s in removeList)
            {
                if (list[i].Equals(s))
                {
                    list.Remove(s);
                }
            }
        }
    }

    void DisplayItem(GameProp itemData, GameObject itemObject)
    {
        SpriteRenderer spr = itemObject.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>("item/" + itemData.SerialNumber);
        TextMesh priceMesh = itemObject.transform.Find("price").GetComponent<TextMesh>();
        int price = GetPrice("item");
        allPrice.Add(priceMesh, price);
        priceMesh.text = price.ToString();
    }

    int GetPrice(string type)
    {
        string[] range = GlobalVariable.priceReflect[type].Split('-');
        int min = int.Parse(range[0]);
        int max = int.Parse(range[1]);
        int price = Random.Range(min, max + 1);
        return price;
    }
}
