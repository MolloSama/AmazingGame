using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using DG.Tweening;

public class IllustrationControl : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject itemPrefab;
    public GameObject monsterPrefab;
    public int currentPage;
    public int maxPageCount;
    private int maxLineCount;
    private List<GameObject> gameObjects = new List<GameObject>();
    public string currentIllustration;
    private float duration = 0.3f;
    // Use this for initialization
    void Start () {
        currentPage = 0;
        maxLineCount = 6;
        maxPageCount = 3*maxLineCount;
        currentIllustration = "card";
    }

    public void LoadIllustration()
    {
        DestoryObject();
        switch (currentIllustration)
        {
            case "card":
                LoadIllustration(GlobalVariable.cardIllustration, cardPrefab);
                break;
            case "item":
                LoadIllustration(GlobalVariable.itemIllustration, itemPrefab);
                break;
            case "monster":
                LoadIllustration(GlobalVariable.monsterIllustration, monsterPrefab);
                break;
        }
    }

    void LoadIllustration(IDictionary dictionary, GameObject g)
    {
        if (dictionary.Count - currentPage * maxPageCount >= maxPageCount)
        {
            StartCoroutine(LoadIllustration(maxPageCount, g));
        }
        else
        {
            StartCoroutine(LoadIllustration(dictionary.Count - currentPage * maxPageCount, g));
        }
    }

    IEnumerator LoadIllustration(int count, GameObject prefab)
    {
        float y = prefab.transform.position.y;
        List<GameProp> props = new List<GameProp>();
        List<Monster> monsters = new List<Monster>();
        switch (currentIllustration)
        {
            case "card":
                props = new List<GameProp>(GlobalVariable.AllCards.Values);
                break;
            case "item":
                props = new List<GameProp>(GlobalVariable.AllGameItems.Values);
                break;
            case "monster":
                monsters = new List<Monster>(GlobalVariable.AllMonsters.Values);
                break;
        }
        for (int i = 0; i < count; ++i)
        {
            if (i % maxLineCount == 0)
            {
                y -= 2.5f;
            }
            GameObject propObject = Instantiate(prefab,
                prefab.transform.position + new Vector3(2.5f * (i % maxLineCount), y, 0), Quaternion.identity);
            gameObjects.Add(propObject);
            GameProp propData = new GameProp("0");
            Monster monsterData = new Monster("0");
            if (props.Count != 0)
            {
                propData = props[i + currentPage * maxPageCount];
            }
            if (monsters.Count != 0)
            {
                monsterData = monsters[i + currentPage * maxPageCount];
            }
            switch (currentIllustration)
            {
                case "card":
                    if (GlobalVariable.cardIllustration.ContainsKey(propData.SerialNumber))
                    {
                        DisplayCard(propData, propObject,
                        GlobalVariable.cardIllustration[propData.SerialNumber]);
                    }
                    break;
                case "item":
                    if (GlobalVariable.itemIllustration.ContainsKey(propData.SerialNumber))
                    {
                        DisplayItem(propData, propObject,
                        GlobalVariable.itemIllustration[propData.SerialNumber]);
                    }
                    break;
                case "monster":
                    if (GlobalVariable.monsterIllustration.ContainsKey(monsterData.SerialNumber))
                    {
                        DisplayMonster(monsterData, propObject,
                       GlobalVariable.monsterIllustration[monsterData.SerialNumber]);
                    }
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void DisplayCard(GameProp cardData, GameObject cardObject, bool isGet)
    {
        Transform skillText = cardObject.transform.Find("skill-text");
        string description = cardData.Description;
        skillText.GetComponent<TextMesh>().text = Regex.Replace(description, @"\S{8}", "$0\r\n");
        DOTween.ToAlpha(() => skillText.GetComponent<TextMesh>().color, 
            x => skillText.GetComponent<TextMesh>().color = x, 1, duration);
        SpriteRenderer cardStyle = cardObject.transform.Find("card-style").GetComponent<SpriteRenderer>();
        Sprite style = Resources.Load<Sprite>("cardStyle/" +
            cardData.Type.Substring(0, 2) + cardData.EnergyConsumption);
        cardStyle.sprite = style;
        DOTween.ToAlpha(() => cardStyle.color, x => cardStyle.color = x, 1, duration);
        Transform cardName = cardObject.transform.Find("card-name");
        cardName.GetComponent<TextMesh>().text = cardData.Name;
        DOTween.ToAlpha(() => cardName.GetComponent<TextMesh>().color, 
            x => cardName.GetComponent<TextMesh>().color = x, 1, duration);
        SpriteRenderer cardRawImg = cardObject.transform.Find("card-raw-img").GetComponent<SpriteRenderer>();
        Sprite rawImg = Resources.Load<Sprite>("cardRawImg/" + cardData.SerialNumber);
        DOTween.ToAlpha(() => cardRawImg.color, x => cardRawImg.color = x, 1, duration);
        cardRawImg.sprite = rawImg;
        if (!isGet)
        {
            cardRawImg.material = Resources.Load<Material>("materials/SpriteGray");
            cardStyle.material = Resources.Load<Material>("materials/SpriteGray");
        }
    }

    void DisplayItem(GameProp itemData, GameObject itemObject, bool isGet)
    {
        SpriteRenderer spr = itemObject.GetComponent<SpriteRenderer>();
        DOTween.ToAlpha(() => spr.color, x => spr.color = x, 1, duration);
        spr.sprite = Resources.Load<Sprite>("item/" + itemData.SerialNumber);
        TextMesh textMesh = itemObject.transform.Find("itemName").GetComponent<TextMesh>();
        DOTween.ToAlpha(() => textMesh.color, x => textMesh.color = x, 1, duration);
        textMesh.text = itemData.Name;
        if (!isGet)
        {
            spr.material = Resources.Load<Material>("materials/SpriteGray");
        }
    }

    void DisplayMonster(Monster monsterData, GameObject monsterObject, bool isGet)
    {
        SpriteRenderer spr = monsterObject.GetComponent<SpriteRenderer>();
        DOTween.ToAlpha(() => spr.color, x => spr.color = x, 1, 0.7f);
        spr.sprite = Resources.Load<Sprite>("monsters/" + monsterData.Code);
        TextMesh textMesh = monsterObject.transform.Find("monsterName").GetComponent<TextMesh>();
        DOTween.ToAlpha(() => textMesh.color, x => textMesh.color = x, 1, duration);
        textMesh.text = monsterData.Name;
        if (!isGet)
        {
            spr.material = Resources.Load<Material>("materials/SpriteGray");
        }
    }

    void DestoryObject()
    {
        foreach (GameObject g in gameObjects)
        {
            Destroy(g);
        }
        gameObjects.Clear();
    }
}
