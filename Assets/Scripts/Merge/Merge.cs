using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DG.Tweening;
using System.Text.RegularExpressions;

public class Merge : MonoBehaviour {

    public MergeManager mergeManager;

    private string mergeNumber;

    public float fadeTime = 0.2f;

	// Use this for initialization
	void Start () {
        //WriteReflectTxt();
	}

    private void OnMouseDown()
    {
        mergeNumber = GlobalVariable.mergeReflect[mergeManager.mergeCards[0].gameProp.SerialNumber + "+" +
            mergeManager.mergeCards[1].gameProp.SerialNumber + "+" + mergeManager.mergeCards[2].gameProp.SerialNumber];
        MergeManager._instance.clearMergeCards = true;
        Sort();
        foreach(GameObject g in MergeManager._instance.cardGridObjects)
        {
            g.GetComponent<BoxCollider2D>().enabled = false;
            SpriteRenderer spriteRenderer1 = g.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer2 = g.transform.Find("number").GetComponent<SpriteRenderer>();
            TextMesh spriteRenderer3 = g.transform.Find("info").GetComponent<TextMesh>();
            DOTween.ToAlpha(() => spriteRenderer1.color, x => spriteRenderer1.color = x, 0, 1f);
            DOTween.ToAlpha(() => spriteRenderer2.color, x => spriteRenderer2.color = x, 0, 1f);
            DOTween.ToAlpha(() => spriteRenderer3.color, x => spriteRenderer3.color = x, 0, 1f);
        }
        StartCoroutine(MergeCardsMove());
        DeleteCards();
        GlobalVariable.ExistingCards.Add(GlobalVariable.AllCards[mergeNumber]);
        StartCoroutine(te());
    }

    private void Sort()
    {
        if (MergeManager._instance.mergeCards[0].index > MergeManager._instance.mergeCards[1].index)
        {
            CardProp temp = MergeManager._instance.mergeCards[0];
            MergeManager._instance.mergeCards[0] = MergeManager._instance.mergeCards[1];
            MergeManager._instance.mergeCards[1] = temp;
        }
        if (MergeManager._instance.mergeCards[0].index > MergeManager._instance.mergeCards[2].index)
        {
            CardProp temp = MergeManager._instance.mergeCards[0];
            MergeManager._instance.mergeCards[0] = MergeManager._instance.mergeCards[2];
            MergeManager._instance.mergeCards[2] = temp;
        }
        if (MergeManager._instance.mergeCards[1].index > MergeManager._instance.mergeCards[2].index)
        {
            CardProp temp = MergeManager._instance.mergeCards[1];
            MergeManager._instance.mergeCards[1] = MergeManager._instance.mergeCards[2];
            MergeManager._instance.mergeCards[2] = temp;
        }
    }

    private void DeleteCards()
    {
        //List<GameProp> fightCardsTemp = new List<GameProp>();
        //List<int> fightCardsIndexTemp = new List<int>();
        //for (int i = 0; i < GlobalVariable.FightCards.Count; i++)
        //{
        //    if (i != MergeManager._instance.mergeCards[0].index &&
        //        i != MergeManager._instance.mergeCards[1].index &&
        //        i != MergeManager._instance.mergeCards[2].index)
        //    {
        //        fightCardsTemp.Add(GlobalVariable.FightCards[i]);
        //        fightCardsIndexTemp.Add(GlobalVariable.FightCardsIndex[i]);
        //    }
        //}
        //GlobalVariable.FightCards.Clear();
        //GlobalVariable.FightCardsIndex.Clear();
        //GlobalVariable.FightCards = fightCardsTemp;
        //GlobalVariable.FightCardsIndex = fightCardsIndexTemp;

        List<GameProp> existingCardsTemp = new List<GameProp>();
        for (int i = 0; i < GlobalVariable.ExistingCards.Count; i++)
        {
            if (i != MergeManager._instance.mergeCards[0].index &&
                i != MergeManager._instance.mergeCards[1].index &&
                i != MergeManager._instance.mergeCards[2].index)
            {
                existingCardsTemp.Add(GlobalVariable.ExistingCards[i]);
            }
        }
        GlobalVariable.ExistingCards.Clear();
        GlobalVariable.ExistingCards = existingCardsTemp;
    }

    private IEnumerator MergeCardsMove()
    {
        float x = MergeManager._instance.mergePosition[3].transform.position.x;
        float y = MergeManager._instance.mergePosition[3].transform.position.y;
        for(int i = 0; i < 3; i++)
        {
            MergeSelect.mergeCardsGrids[i].transform.DOMove(new Vector3(x, y), 0.5f);
            yield return new WaitForSeconds(0.6f);
            Destroy(MergeSelect.mergeCardsGrids[i]);
            MergeSelect.mergeCardsGrids[i] = null;
        }
        GameObject temp = Instantiate(Resources.Load<GameObject>("cardpanel/merge"),
                                    new Vector3(MergeManager._instance.mergePosition[3].transform.position.x,
                                                MergeManager._instance.mergePosition[3].transform.position.y),
                                    Quaternion.identity);
        temp.transform.parent = gameObject.transform.parent;
        temp.GetComponent<BoxCollider2D>().enabled = false;
        GameProp card = GlobalVariable.AllCards[mergeNumber];
        foreach (Transform t in temp.transform)
        {
            switch (t.name)
            {
                case "skill-text":
                    t.GetComponent<TextMesh>().text =
                        Regex.Replace(card.Description, @"\S{8}", "$0\r\n");
                    break;
                case "card-name":
                    t.GetComponent<TextMesh>().text = card.Name;
                    break;
                case "card-raw-img":
                    t.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("cardRawImg/{0}", card.SerialNumber));
                    break;
                case "card-style":
                    Sprite style = Resources.Load<Sprite>("cardStyle/" + card.Type.Substring(0, 2) + card.EnergyConsumption);
                    t.GetComponent<SpriteRenderer>().sprite = style;
                    break;
                default:
                    break;
            }
        }
        temp.transform.DOScale(new Vector3(temp.transform.localScale.x * 2.0f, temp.transform.localScale.y * 2.0f), 1.0f).OnComplete(() => Destroy(temp));
    }

    private IEnumerator te()
    {
        yield return new WaitForSeconds(2.0f);
        MergeManager._instance.LoadCards();
    }

    void WriteReflectTxt()
    {
        FileStream fs = new FileStream("C:/Users/admin/Documents/GitHub/AmazingGame/Assets/merge-reflect.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        //开始写入
        for(int i = 1; i <= 12; ++i)
        {
            for (int j = 1; j <= 12; ++j)
            {
                for (int k = 1; k <= 12; ++k)
                {
                    string s = i.ToString("D" + 3) + "+" + j.ToString("D" + 3) + "+" + k.ToString("D" + 3)+"=012";
                    sw.WriteLine(s);
                }
            }
        }
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
    }
}
