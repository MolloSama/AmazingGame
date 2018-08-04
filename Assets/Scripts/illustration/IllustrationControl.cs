using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class IllustrationControl : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject itemPrefab;
    public GameObject monsterPrefab;
    public int currentPage;
    public int maxPageCount;
    private int maxLineCount;
    private List<GameObject> gameObjects = new List<GameObject>();
    public string currentIllustration;
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
            LoadIllustration(maxPageCount, g);
        }
        else
        {
            LoadIllustration(dictionary.Count - currentPage * maxPageCount, g);
        }
    }

    void LoadIllustration(int count, GameObject prefab)
    {
        float y = prefab.transform.position.y;
        List<GameProp> props = new List<GameProp>();
        List<Monster> monsters = new List<Monster>();
        switch (currentIllustration)
        {
            case "card":
                props = new List<GameProp>(GlobalVariable.cardIllustration.Keys);
                break;
            case "item":
                props = new List<GameProp>(GlobalVariable.itemIllustration.Keys);
                break;
            case "monster":
                monsters = new List<Monster>(GlobalVariable.monsterIllustration.Keys);
                break;
        }
        for (int i = 0; i < count; ++i)
        {
            if (i % maxLineCount == 0)
            {
                y -= 2.5f;
            }
            GameObject prop = Instantiate(prefab,
                prefab.transform.position + new Vector3(2.5f * (i % maxLineCount), y, 0), Quaternion.identity);
            switch (currentIllustration)
            {
                case "card":
                    DisplayCard(props[i + currentPage * maxPageCount], prop, 
                        GlobalVariable.cardIllustration[props[i + currentPage * maxPageCount]]);
                    break;
                case "item":
                    DisplayItem(props[i + currentPage * maxPageCount], prop, 
                        GlobalVariable.itemIllustration[props[i + currentPage * maxPageCount]]);
                    break;
                case "monster":
                    DisplayMonster(monsters[i + currentPage * maxPageCount], prop, 
                        GlobalVariable.monsterIllustration[monsters[i + currentPage * maxPageCount]]);
                    break;
            }
            gameObjects.Add(prop);
        }
    }

    void DisplayCard(GameProp cardData, GameObject cardObject, bool isGet)
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
        if (!isGet)
        {
            cardRawImg.material = Resources.Load<Material>("materials/SpriteGray");
            cardStyle.material = Resources.Load<Material>("materials/SpriteGray");
        }
    }

    void DisplayItem(GameProp itemData, GameObject itemObject, bool isGet)
    {
        SpriteRenderer spr = itemObject.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>("item/" + itemData.SerialNumber);
        TextMesh textMesh = itemObject.transform.Find("itemName").GetComponent<TextMesh>();
        textMesh.text = itemData.Name;
        if (!isGet)
        {
            spr.material = Resources.Load<Material>("materials/SpriteGray");
        }
    }

    void DisplayMonster(Monster monsterData, GameObject monsterObject, bool isGet)
    {
        SpriteRenderer spr = monsterObject.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>("monsters/" + monsterData.Code);
        TextMesh textMesh = monsterObject.transform.Find("monsterName").GetComponent<TextMesh>();
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
