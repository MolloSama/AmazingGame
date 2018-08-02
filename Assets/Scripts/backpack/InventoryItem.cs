using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class InventoryItem : MonoBehaviour {
    private GameProp item;
    public GameProp Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        GameObject gameObject = GameObject.Find("objectInfo");
        if (item != null)
            gameObject.GetComponent<TextMesh>().text = string.Format(item.Name+"：\n{0}", 
                Regex.Replace(item.Description, @"\S{22}", "$0\r\n"));
        else
            gameObject.GetComponent<TextMesh>().text = "";
    }

    private void OnMouseExit()
    {
        GameObject gameObject = GameObject.Find("objectInfo");
        gameObject.GetComponent<TextMesh>().text = "";
    }

}
