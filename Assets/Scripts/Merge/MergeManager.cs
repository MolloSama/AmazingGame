using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using DG.Tweening;

public class MergeManager : MonoBehaviour {

    private readonly float startX = -3.8f;

    private readonly float startY = 3.6f;

    private readonly float startZ = 0.0f;

    private readonly float grap = -0.8f;

    public List<GameObject> cardGridObjects = new List<GameObject>();

    public CardProp[] mergeCards = new CardProp[3];

    public GameObject[] mergePosition = new GameObject[4];

    private int index = 0;

    public static MergeManager _instance;

    public GameObject mergeButton;

    public bool clearMergeCards = false;

    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
	}

    public void AnShow()
    {
        LoadCards();
    }

    private void Update()
    {
        if (JudgeArrayNull())
        {
            mergeButton.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            mergeButton.SetActive(false);
        }
        else
        {
            mergeButton.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            mergeButton.SetActive(true);
        }
    }

    bool JudgeArrayNull()
    {
        foreach (CardProp cardProp in mergeCards)
        {
            
            if (cardProp == null)
            {
                return true;
            }
        }
        return false;
    }

    public void LoadCards()
    {
        if (clearMergeCards)
        {
            for (int i = 0; i < 3; i++)
                mergeCards[i] = null;
        }
        clearMergeCards = false;
        foreach (GameObject t in cardGridObjects)
        {
            if(t!=null)
                Destroy(t);
        }
        cardGridObjects.Clear();
        if (index >= GlobalVariable.ExistingCards.Count)
            index -= 9;
        for (int i = 0; i < 9 && (i + index) < GlobalVariable.ExistingCards.Count; i++)
        {
            bool contains = false;
            for(int j = 0; j < 3; j++)
            {
                if (mergeCards[j] != null && mergeCards[j].index == i + index)
                {
                    contains = true;
                    break;
                }
            }
            GameObject temp = Instantiate(Resources.Load<GameObject>("cardpanel/bar"), 
                new Vector3(startX, startY + i * grap, startZ), 
                Quaternion.identity);
            temp.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("cardpanel/" + GlobalVariable.ExistingCards[i + index].SerialNumber);
            temp.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            DOTween.ToAlpha(() => temp.GetComponent<SpriteRenderer>().color, x => temp.GetComponent<SpriteRenderer>().color = x, 1, 0.3f);
            temp.transform.Find("info").GetComponent<TextMesh>().text = GlobalVariable.ExistingCards[i + index].Name;
            temp.transform.Find("number").GetComponent<SpriteRenderer>().sprite = 
                Resources.Load<Sprite>("cardpanel/" + 
                                        GlobalVariable.ExistingCards[i + index].Type.Substring(0, 2) + 
                                        GlobalVariable.ExistingCards[i + index].EnergyConsumption);
            temp.transform.Find("number").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            DOTween.ToAlpha(() => temp.transform.Find("number").GetComponent<SpriteRenderer>().color, x => temp.transform.Find("number").GetComponent<SpriteRenderer>().color = x, 1, 0.3f);
            if (contains)
            {
                temp.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                temp.transform.Find("number").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
            }
            temp.GetComponent<MergeSelect>().LoadCard(GlobalVariable.ExistingCards[i + index], i + index);
            cardGridObjects.Add(temp);
            temp.transform.parent = gameObject.transform;
        }
    }

    public void NextPage()
    {
        if (index + 9 < GlobalVariable.ExistingCards.Count)
        {
            index += 9;
            LoadCards();
        }
    }

    public void PrevPage()
    {
        if (index - 9 >= 0)
        {
            index -= 9;
            LoadCards();
        }
    }

}
