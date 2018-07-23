using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TertiaryMapSelect : MonoBehaviour {

    private static string sceneName;

    public static bool setOver = false;

    private int count = 0;

    // Use this for initialization
    void Start () {
        GameObject.Find("mountain").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("map/{0}", sceneName));
        LoadMountains();
        setOver = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetScene(string temp)
    {
        sceneName = temp;
        GlobalVariable.preMap = temp;
        setOver = true;
    }

    private void LoadMountains()
    {
        if (sceneName.Split('-').Length == 3)
        {
            sceneName = sceneName.Split('-')[0] + '-' + sceneName.Split('-')[1];
        }
        for(int i=1; ; i++)
        {
            MountainInformation mountainInformation;
            if (GlobalVariable.Mountains.TryGetValue(sceneName + '-' + i, out mountainInformation))
            {
                count++;
                GameObject temp = Instantiate(Resources.Load<GameObject>("map/tertiarymountain"), new Vector3(mountainInformation.x, mountainInformation.y), Quaternion.identity);
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



                //if (mountainInformation.status)
                //    temp.transform.Find("hillstatus").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("map/mark");
            }
            else break;
        }
        PanelControl.count = count;
    }
}
