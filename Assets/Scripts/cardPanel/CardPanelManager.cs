using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CardPanelManager : MonoBehaviour
{

    private readonly float firstPositionX = 0.375f;

    private readonly float firstPositionY = 2.4f;

    private readonly float firstPositionZ = 1.0f;

    private readonly float grapX = 1.598f;

    private readonly float grapY = -2.396f;

    private int index = 0;

    private readonly int row = 3;

    private readonly int column = 4;

    public static CardPanelManager _instance;

    private List<GameObject> cardgridobjects = new List<GameObject>();


    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        CardSelect.LoadData();
        LoadCards();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CancelSelect(CardProp card)
    {
        foreach (GameObject t in cardgridobjects)
        {
            if (t.GetComponent<CardSelect>().gameProp.Equal(card.index))
            {
                t.transform.Find("card-style").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
                t.transform.Find("card-raw-img").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
            }
        }
    }



    private void LoadCards()
    {
        foreach (GameObject t in cardgridobjects)
        {
            Destroy(t);
        }
        cardgridobjects.Clear();

        for (int i = 0; i < row * column && (i + index) < GlobalVariable.ExistingCards.Count; i++)
        {
            bool contains = false;
            for (int j = 0; j < CardSelect.count; j++)
            {
                if (CardSelect.fightCardsGrids[j].Equal(i + index))
                {
                    contains = true;
                    break;
                }
            }
            GameObject temp = Instantiate(Resources.Load<GameObject>("cardpanel/card"), new Vector3(firstPositionX + (i % column) * grapX, firstPositionY + (i / column) * grapY, firstPositionZ), Quaternion.identity);
            temp.GetComponent<CardSelect>().LoadCard(GlobalVariable.ExistingCards[i + index], i + index);
            cardgridobjects.Add(temp);
            temp.transform.parent = gameObject.transform;
            foreach (Transform t in temp.transform)
            {
                switch (t.name)
                {
                    case "skill-text":
                        t.GetComponent<TextMesh>().text =
                            Regex.Replace(GlobalVariable.ExistingCards[i + index].Description, @"\S{8}", "$0\r\n");
                        break;
                    case "card-name":
                        t.GetComponent<TextMesh>().text = GlobalVariable.ExistingCards[i + index].Name;
                        break;
                    case "card-raw-img":
                        t.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("cardRawImg/{0}", GlobalVariable.ExistingCards[i + index].SerialNumber));
                        if (contains)
                            t.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                        break;
                    case "card-style":
                        Sprite style = Resources.Load<Sprite>("cardStyle/" +
               GlobalVariable.ExistingCards[i + index].Type.Substring(0, 2) + GlobalVariable.ExistingCards[i + index].EnergyConsumption);
                        t.GetComponent<SpriteRenderer>().sprite = style;
                        if (contains)
                            t.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void NextPage()
    {
        if (index + row * column < GlobalVariable.ExistingCards.Count)
        {
            index += row * column;
            LoadCards();
        }
    }

    public void PrevPage()
    {
        if (index - row * column >= 0)
        {
            index -= row * column;
            LoadCards();
        }
    }
}
