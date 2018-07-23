using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour {
    private CardProp gameProp = null;

    public static bool clickable = true;

    public int index;


    public static void Clear()
    {
        clickable = true;
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetGameProp(CardProp temp)
    {
        gameProp = temp;
    }

    private void OnMouseUpAsButton()
    {
        if (clickable)
        {
            CardPanelManager._instance.CancelSelect(gameProp);
            CardSelect._instance.CallAlterFithtGrids(false, index);
        }
    }

    public string Name()
    {
        return gameProp.gameProp.Name;
    }
}
