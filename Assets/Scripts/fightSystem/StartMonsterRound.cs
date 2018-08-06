using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMonsterRound : MonoBehaviour {

    public GameControll gameControll;
    private bool isClick = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gameControll.isMonsterRoundOver && isClick)
        {
            StartCoroutine(AddCards());
            gameControll.isMonsterRoundOver = false;
            isClick = false;
        }
    }

    private void OnMouseDown()
    {
        if (gameControll.isAnimationEnd)
        {
            StartCoroutine(JudgeKrakenStatus());
            gameControll.SetEnergyFull();
            gameControll.isMonsterFight = true;
            isClick = true;
            gameControll.ClickSelectedMonster();
            gameControll.ClickSelectedCard();
            gameControll.isAnimationEnd = false;
        }
    }

    IEnumerator JudgeKrakenStatus()
    {
        yield return new WaitForSeconds(gameControll.monsterNumber.Count * 0.6f);
        gameControll.JudegStatus(gameControll.kraken, gameControll.krakenObject.transform.position);
    }

    IEnumerator AddCards()
    {
        yield return new WaitForSeconds(0.5f);
        gameControll.AddTwoCards();
    }
}
