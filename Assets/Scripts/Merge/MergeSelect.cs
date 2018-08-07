using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MergeSelect : MonoBehaviour {

    public CardProp card;
    public bool isMerge = false;
    public bool isSelect = false;
    public int number;
    public static GameObject[] mergeCardsGrids = new GameObject[3];

    public static void Clear()
    {
        for(int i=0;i<3;i++)
        {
            Destroy(mergeCardsGrids[i]);
            mergeCardsGrids[i] = null;
        }
    }

	// Use this for initialization
	void Start () {
		
	}

    public void LoadCard(GameProp prop,int index)
    {
        card = new CardProp(prop, index);
    }
    private void OnMouseUpAsButton()
    {
        if (!isMerge && !isSelect) 
        {
            for (int i = 0; i < MergeManager._instance.mergeCards.Length; i++)
            {
                if (MergeManager._instance.mergeCards[i] == null)
                {
                    isSelect = true;
                    GameObject temp =
                        Instantiate(Resources.Load<GameObject>("cardpanel/merge"),
                        new Vector3(MergeManager._instance.mergePosition[i].transform.position.x,
                                    MergeManager._instance.mergePosition[i].transform.position.y,
                                    MergeManager._instance.mergePosition[i].transform.position.z),
                        Quaternion.identity);
                    temp.GetComponent<MergeSelect>().LoadCard(card.gameProp, card.index);
                    temp.GetComponent<MergeSelect>().isMerge = true;
                    temp.GetComponent<MergeSelect>().number = i;

                    temp.transform.parent = gameObject.transform.parent.parent;
                    foreach (Transform t in temp.transform)
                    {
                        switch (t.name)
                        {
                            case "skill-text":
                                t.GetComponent<TextMesh>().text =
                                    Regex.Replace(card.gameProp.Description, @"\S{8}", "$0\r\n");
                                break;
                            case "card-name":
                                t.GetComponent<TextMesh>().text = card.gameProp.Name;
                                break;
                            case "card-raw-img":
                                t.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("cardRawImg/{0}", card.gameProp.SerialNumber));
                                //if (contains)
                                //    t.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                                break;
                            case "card-style":
                                Sprite style = Resources.Load<Sprite>("cardStyle/" +
                       card.gameProp.Type.Substring(0, 2) + card.gameProp.EnergyConsumption);
                                t.GetComponent<SpriteRenderer>().sprite = style;
                                //if (contains)
                                //    t.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                                break;
                            default:
                                break;
                        }
                    }
                    gameObject.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                    gameObject.transform.Find("number").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/SpriteGray");
                    MergeManager._instance.mergeCards[i] = card;
                    mergeCardsGrids[i] = temp;
                    break;
                }
            }
        }
        if (isMerge)
        {
            foreach(GameObject t in MergeManager._instance.cardGridObjects)
            {
                if (t.GetComponent<MergeSelect>().card.index.Equals(card.index))
                {
                    t.GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
                    t.transform.Find("number").GetComponent<SpriteRenderer>().material = Resources.Load<Material>("materials/Default");
                    t.GetComponent<MergeSelect>().isSelect = false;
                }
            }
            MergeManager._instance.mergeCards[number] = null;
            Destroy(gameObject);
            int i = gameObject.GetComponent<MergeSelect>().number;
            mergeCardsGrids[i] = null;
        }
    }
}
