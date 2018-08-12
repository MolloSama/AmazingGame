using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BarScript : MonoBehaviour
{
    private CardProp gameProp = null;

    public static bool clickable = true;

    public int index;


    public static void Clear()
    {
        clickable = true;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetGameProp(CardProp temp)
    {
        gameProp = temp;
    }

    private void OnMouseUpAsButton()
    {
        if (clickable)
        {
            if (CardSelect.count != 1)
            {
                CardPanelManager._instance.CancelSelect(gameProp);
                CardSelect._instance.CallAlterFithtGrids(false, index);
            }
            else
            {
                GameObject temp = GameObject.Find("Tip");
                DOTween.ToAlpha(() => temp.GetComponent<TextMesh>().color, x => temp.GetComponent<TextMesh>().color = x, 1, 0.5f).OnComplete(()=>
                {
                    DOTween.ToAlpha(() => temp.GetComponent<TextMesh>().color, x => temp.GetComponent<TextMesh>().color = x, 1, 0.5f).OnComplete(()=>
                    {
                        DOTween.ToAlpha(() => temp.GetComponent<TextMesh>().color, x => temp.GetComponent<TextMesh>().color = x, 0, 0.3f);
                    });
                });
            }
        }
    }

    public string Name()
    {
        return gameProp.gameProp.Name;
    }
}
