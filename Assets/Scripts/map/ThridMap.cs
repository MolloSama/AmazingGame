using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridMap : MonoBehaviour {

    public static string sceneName;

    private int count = 0;

    public static ThridMap _instance;

    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {
    }

    public void AnShow()
    {
        GlobalVariable.sceneflag = 3;
        GameObject.Find("mountain").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("map/{0}", sceneName));
        LoadMountains();
    }

    public static void SetScene(string temp)
    {
        sceneName = temp;
        GlobalVariable.preMap = temp;
    }

    private void LoadMountains()
    {
        if (sceneName.Split('-').Length == 3)
        {
            sceneName = sceneName.Split('-')[0] + '-' + sceneName.Split('-')[1];
        }
        for (int i = 1; ; i++)
        {
            MountainInformation mountainInformation;
            if (GlobalVariable.Mountains.TryGetValue(sceneName + '-' + i, out mountainInformation))
            {
                count++;
                GameObject temp = Instantiate(Resources.Load<GameObject>("map/tertiarymountain"), new Vector3(mountainInformation.x * 0.8f, mountainInformation.y * 0.8f), Quaternion.identity);
                temp.transform.parent = gameObject.transform.parent;
                temp.transform.localScale = new Vector3(temp.transform.localScale.x * 0.8f, temp.transform.localScale.y * 0.8f);
                temp.GetComponent<IntoFight>().mountainInformation = mountainInformation;
                temp.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("map/mountain" + mountainInformation.index % 3);
                temp.transform.Find("hillname").GetComponent<TextMesh>().text = mountainInformation.name;
                temp.name = count.ToString();
                foreach (string t in GlobalVariable.HasFightScenes)
                {
                    if (t.Equals(sceneName + '-' + i))
                    {
                        temp.transform.Find("hillstatus").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("map/mark");
                        break;
                    }

                }
            }
            else break;
        }
        PanelControl.count = count;
        CloseIcon.count = count;
    }
}
