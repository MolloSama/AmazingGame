using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction : MonoBehaviour {

    GameObject bigCard;
    public int index;
    public static bool isCardSelected = false;
    public static int increaseIndex = -1;
    public static int currentIndex = -1; 
    private SpriteRenderer style;
    public GameControll gameControll;
    private bool isFirstOver = true;

    private void Awake()
    {
        gameControll = GameObject.Find("gameControll").GetComponent<GameControll>();
        style = transform.Find("card-style").GetComponent<SpriteRenderer>();
        index = ++increaseIndex;
    }

    private void OnDestroy()
    {
        if(gameControll.playButton != null)
        {
            gameControll.playButton.SetActive(false);
        }             
    }
    
    public void OnMouseDown()
    {
        if (gameControll.isAnimationEnd && !gameControll.isDrawCard)
        {
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            style.GetPropertyBlock(block);
            if (!isCardSelected)
            {
                block.SetFloat("_OffsetUV", 0.027f);
                style.SetPropertyBlock(block);
                isCardSelected = true;
                currentIndex = index;
                gameControll.ClickCard();
                return;
            }
            if (currentIndex == index)
            {
                gameControll.ClickSelectedMonster();
                block.SetFloat("_OffsetUV", 0.0f);
                style.SetPropertyBlock(block);
                isCardSelected = false;
                RenderMonster.needClickMonster = false;
                gameControll.ClickSelectedMonster();
                currentIndex = -1;
            }
        } 
    }

    private IEnumerator OnMouseOver()
    {
        if (gameControll.isAnimationEnd && isFirstOver && !gameControll.isDrawCard)
        {
            gameObject.transform.Translate(new Vector3(0, 0.1f, 0));
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            bigCard = Instantiate(gameObject, new Vector3(x, y + 0.7f, 0), Quaternion.identity)
                as GameObject;
            --increaseIndex;
            bigCard.transform.localScale *= 2;
            Destroy(bigCard.GetComponent<CardAction>());
            isFirstOver = false;
        }
        yield return new WaitForSeconds(0.3f);
    }

    private void OnMouseExit()
    {
        if (gameControll.isAnimationEnd && !gameControll.isDrawCard && !isFirstOver)
        {
            Destroy(bigCard);
            gameObject.transform.Translate(new Vector3(0, -0.1f, 0));
            isFirstOver = true;
        }
    }
}
