using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory _instance;

    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();

    private List<ObjectItem> battleItemsList = new List<ObjectItem>();

    private List<ObjectItem> plotItemsList = new List<ObjectItem>();

    private bool isBattlePanel = true;

    private int firstItem = 0;

    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {
        Init();
        ShowItems();
        GameObject.Find("kraken").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("kraken/kraken");

        GameObject.Find("krakenInfo").GetComponent<TextMesh>().text = string.Format("属性：无\n" +
                                                                                  "名字：{0}\n" +
                                                                                  "攻击：{1}\n" +
                                                                                  "防御：{2}\n" +
                                                                                  "血量：{3}\n",
                                                                                  "鲲灵", GlobalVariable.kraKen.AttactPower, GlobalVariable.kraKen.DefensivePower, GlobalVariable.kraKen.BloodVolume);



    }

	// Update is called once per frame
	void Update () {
		
	}

    private void Init()
    {
        foreach (GameProp t in GlobalVariable.BattleItems)
        {
            battleItemsList.Add(new ObjectItem(t, 1));
        }
        foreach (GameProp t in GlobalVariable.PlotItems)
        {
            plotItemsList.Add(new ObjectItem(t, 1));
        }
    }

    public void SwitchPanel()
    {
        firstItem = 0;
        isBattlePanel = !isBattlePanel;
        ShowItems();
    }

    private void ShowItems()
    {
        foreach (InventoryItemGrid t in itemGridList)
        {
            t.SetItem(null);
        }
        if (isBattlePanel)
        {
            for (int i = firstItem; i < firstItem + itemGridList.Count && i < battleItemsList.Count; i++) 
            {
                itemGridList[i - firstItem].SetItem(battleItemsList[i].GetProp());
            }
        }
        else
        {
            for (int i = firstItem; i < firstItem + itemGridList.Count && i < plotItemsList.Count; i++) 
            {
                itemGridList[i - firstItem].SetItem(plotItemsList[i].GetProp());
            }
        }
    }

    public void NextPage()
    {
        if (isBattlePanel)
        {
            if (firstItem + itemGridList.Count < battleItemsList.Count)
            {
                firstItem += itemGridList.Count;
                ShowItems();
            }
        }
        else
        {
            if (firstItem + itemGridList.Count < plotItemsList.Count)
            {
                firstItem += itemGridList.Count;
                ShowItems();
            }
        }
    }

    public void PrevPage()
    {
        if (isBattlePanel)
        {
            if (firstItem - itemGridList.Count >= 0) 
            {
                firstItem -= itemGridList.Count;
                ShowItems();
            }
        }
        else
        {
            if (firstItem - itemGridList.Count >= 0) 
            {
                firstItem -= itemGridList.Count;
                ShowItems();
            }
        }
    }

    private bool isShow = false;

    //private void LoadData()
    //{
    //    string item_battle_object = Resources.Load("data/item_battle").ToString();
    //    string[] item_battle_data = item_battle_object.ToString().Split('\n');
    //    foreach(string i in item_battle_data)
    //    {
    //        //字长为17

    //        string[]data  = i.Split(',');




    //        if (data.Length == 11)
    //        {
    //            StringBuilder stringBuilder = new StringBuilder();
    //            for (int index = 0; index < data[4].Length; index += 16)
    //            {
    //                if (index + 16 < data[4].Length)
    //                {
    //                    stringBuilder.Append(data[4].Substring(index, 16)).Append('\n');
    //                }
    //                else
    //                {
    //                    stringBuilder.Append(data[4].Substring(index, data[4].Length - index));
    //                }
    //            }

    //            GlobalVariable.BattleItems.Add(new GameProp(data[0], data[1], int.Parse(data[2]),
    //                data[3], stringBuilder.ToString(), float.Parse(data[5]), int.Parse(data[6]),
    //                int.Parse(data[7]), int.Parse(data[8]), data[9], data[10]));
    //        }
    //    }
    //}




    private void Show()
    {
        isShow = true;
    }

    private void Hide()
    {
        isShow = false;
    }


    public void TransformState()
    {
        if (!isShow)
        {
            Show();
            isShow = true;
        }
        else
        {
            Hide();
            isShow = false;
        }
    }
}
class ObjectItem
{
    GameProp gameProp;
    int num;
    public ObjectItem()
    {

    }
    public ObjectItem(GameProp t,int p)
    {
        gameProp = t;
        num = p;
    }
    public void Increase()
    {
        num++;
    }
    public GameProp GetProp()
    {
        return gameProp;
    }
}
