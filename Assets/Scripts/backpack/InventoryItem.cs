using System.Collections;
using System.Collections.Generic;
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
            gameObject.GetComponent<TextMesh>().text = string.Format("道具描述：\n{0}", item.Description);
        else
            gameObject.GetComponent<TextMesh>().text = "";
    }

    private void OnMouseExit()
    {
        GameObject gameObject = GameObject.Find("objectInfo");
        gameObject.GetComponent<TextMesh>().text = "";
    }

}
