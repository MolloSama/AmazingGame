using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DisplayDetail : MonoBehaviour {

    private TextMesh detail;
	// Use this for initialization
	void Start () {
        detail = GameObject.Find("detail").GetComponent<TextMesh>();
	}

    private void OnMouseEnter()
    {
        GameProp prop = StoreControl.reflect[gameObject];
        if(prop != null)
        {
            string text = Regex.Replace(prop.Name + ": " + prop.Description, @"\S{22}", "$0\r\n");
            detail.text = text;
        }
    }

    private void OnMouseExit()
    {
        detail.text = "";
    }
}
