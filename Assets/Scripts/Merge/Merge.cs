using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using DG.Tweening;

public class Merge : MonoBehaviour {

    public MergeManager mergeManager;

	// Use this for initialization
	void Start () {
        //WriteReflectTxt();
	}

    private void OnMouseDown()
    {
        string mergeNumber = GlobalVariable.mergeReflect[mergeManager.mergeCards[0].gameProp.SerialNumber + "+" +
            mergeManager.mergeCards[1].gameProp.SerialNumber + "+" + mergeManager.mergeCards[2].gameProp.SerialNumber];
        GlobalVariable.ExistingCards.Add(GlobalVariable.AllCards[mergeNumber]);
        foreach (CardProp cardProp in mergeManager.mergeCards)
        {
            //GlobalVariable.ExistingCards.RemoveAt(cardProp.index);
            //if (GlobalVariable.FightCards.Contains(cardProp.gameProp))
            //{
            //    GlobalVariable.FightCards.Remove(cardProp.gameProp);
            //}

            Sort();
            StartCoroutine(Move());



        }
        
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

    private IEnumerator Move()
    {
        for (int q = 0; q < 3; q++)
        {
            int count = 1;
            foreach (GameObject t in MergeManager._instance.cardGridObjects)
            {
                if (t != null && t.GetComponent<MergeSelect>().card.index.Equals(MergeManager._instance.mergeCards[q].index))
                {
                    Destroy(t);
                    break;
                }
                count++;
            }
            for (int i = count; i < 9; i++)
            {

                float x = MergeManager._instance.cardGridObjects[i].transform.position.x;
                float y = MergeManager._instance.cardGridObjects[i].transform.position.y + 0.8f;
                float z = MergeManager._instance.cardGridObjects[i].transform.position.z;
                MergeManager._instance.cardGridObjects[i - 1] = MergeManager._instance.cardGridObjects[i];
                GameObject temp = Instantiate(Resources.Load<GameObject>("cardpanel/bar"),
                                 new Vector3(4.0f, -3.8f, 0.0f),
                                 Quaternion.identity);
                MergeManager._instance.cardGridObjects[i].transform.DOMove(new Vector3(x, y, z), 0.2f);
            }
            
            yield return new WaitForSeconds(0.25f);
        }
        for (int i = 0; i < 3; i++)
            mergeManager.mergeCards[i] = null;

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
