using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMap : MonoBehaviour {

    private static string sceneName;

    private string num = "1";

    public GameObject circle;
    public static GameObject temp;

    // Use this for initialization
    void Start () {
        GlobalVariable.sceneflag = 2;
	}
    public static void SetScene(string temp)
    {
        sceneName = temp;
    }

    public void OnMouseUpAsButton()
    {
        Destroy(SecondMap.temp);
        if (sceneName == null)
        {
            sceneName = num;
        }
        ThridMap.SetScene(sceneName + '-' + gameObject.name);
        gameObject.transform.parent.gameObject.SetActive(false);
        GameObject temp = Instantiate(Resources.Load<GameObject>("PanelPrefabs/ThridMap"), new Vector3(0, 0, 0), Quaternion.identity);
        temp.name = "Map";
        PanelControl.openObject = temp;
        Destroy(gameObject.transform.parent.gameObject);
        ThridMap._instance.AnShow();
    }
    private void OnMouseEnter()
    {
        sceneName = GlobalVariable.middleMap.Split('-')[0];
        temp = Instantiate(circle, new Vector3(GlobalVariable.SecondMapPosition[sceneName + '-' + gameObject.name][0],
            GlobalVariable.SecondMapPosition[sceneName + '-' + gameObject.name][1]), Quaternion.identity);
    }
    private void OnMouseExit()
    {
        if (temp != null)
            Destroy(temp);
    }
}
