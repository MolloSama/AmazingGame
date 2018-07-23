﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CardRender : MonoBehaviour {

    public GameObject cardPrefab;
    public Transform cardStartPosition;

	// Use this for initialization
	void Start () {
        int count = Random.Range(1, 4);
        if (GlobalVariable.HasFightScenes.Contains(GlobalVariable.currentScene))
        {
            if (GlobalVariable.Chance(50))
            {
                count = 1;
            }
            else
            {
                count = 0;
            }
        }
        for(int i = 0; i < count; ++i)
        {
            GameObject card = Instantiate(cardPrefab,
                cardStartPosition.position+new Vector3(i*4.65f, 0, 0), Quaternion.identity);
            card.transform.parent = transform;
            int randomIndex = Random.Range(0, GlobalVariable.AllCards.Keys.Count);
            List<string> keys = new List<string>(GlobalVariable.AllCards.Keys);
            GameProp randomCard = GlobalVariable.AllCards[keys[randomIndex]];
            Transform skillText = card.transform.Find("skill-text");
            string description = randomCard.Description;
            skillText.GetComponent<TextMesh>().text = Regex.Replace(description, @"\S{8}", "$0\r\n");
            SpriteRenderer cardStyle = card.transform.Find("card-style").GetComponent<SpriteRenderer>();
            Sprite style = Resources.Load<Sprite>("cardStyle/" +
                randomCard.Type.Substring(0, 2) + randomCard.EnergyConsumption);
            cardStyle.sprite = style; 
            Transform cardName = card.transform.Find("card-name");
            cardName.GetComponent<TextMesh>().text = randomCard.Name;
            SpriteRenderer cardRawImg = card.transform.Find("card-raw-img").GetComponent<SpriteRenderer>();
            Sprite rawImg = Resources.Load<Sprite>("cardRawImg/" + randomCard.SerialNumber);
            cardRawImg.sprite = rawImg;
            cardRawImg.sortingOrder = cardStyle.sortingOrder + 1;
            GlobalVariable.ExistingCards.Add(randomCard);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
