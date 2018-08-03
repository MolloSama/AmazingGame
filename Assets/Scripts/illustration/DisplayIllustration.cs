using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DisplayIllustration : MonoBehaviour {

    public GameObject cardPrefab;
    public int currentPage;
    public int maxPageCount;
    private int maxLineCount;
    private List<GameObject> gameObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
        currentPage = 0;
        maxPageCount = 21;
        maxLineCount = 7;
    }

    private void OnMouseDown()
    {
        //if (GlobalVariable.ExistingMissions.Count - currentPage * maxPageCount >= maxPageCount)
        //{
        //    LoadMissionTitle(maxCount);
        //}
        //else
        //{
        //    LoadMissionTitle(GlobalVariable.ExistingMissions.Count - currentPage * maxPageCount);
        //}
        //LoadIllustration(12, cardPrefab);
    }

    void LoadIllustration(int count, GameObject prefab)
    {
        float y = prefab.transform.position.y;
        List<GameProp> props = new List<GameProp>(GlobalVariable.cardIllustration.Keys);
        for (int i = 0; i < count; ++i)
        {
            print(i % maxLineCount);
            if(i % maxLineCount == 0)
            {
                y -= 2.5f;
            }
            GameObject prop = Instantiate(prefab, 
                prefab.transform.position+new Vector3(2f * (i % maxLineCount), y, 0), Quaternion.identity);
            DisplayCard(props[i], prop);
            gameObjects.Add(prop);
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
