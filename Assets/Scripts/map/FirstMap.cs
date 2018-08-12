using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GlobalVariable.sceneflag = 1;
    }

    private void OnMouseUpAsButton()
    {
        GlobalVariable.topMap = gameObject.name;
        Destroy(ButtonFlow.temp);
        SecondMap.SetScene(gameObject.name);
        gameObject.transform.parent.gameObject.SetActive(false);
        GameObject temp = Instantiate(Resources.Load<GameObject>("PanelPrefabs/SecondMap" + gameObject.name), new Vector3(0, 0, 0), Quaternion.identity);
        temp.name = "Map";
        PanelControl.openObject = temp;
        Destroy(gameObject.transform.parent.gameObject);
    }
}
