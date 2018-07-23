using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayCard : MonoBehaviour {

    public GameControll gameControll;
	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        if (gameControll.PlayCard())
        {
            transform.localScale = new Vector3(1, 1, 1);
            gameControll.ClickSelectedMonster();
            RenderMonster.needClickMonster = false;
            CardAction.currentIndex = -1;
        }
    }
}
