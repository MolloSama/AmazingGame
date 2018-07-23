using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMonster : MonoBehaviour {
    SpriteRenderer spr;
    static int increaseIndex = -1;
    public static int currentIndex = -1;
    public static bool isMonsterSelected = false;
    int index;
    public static bool needClickMonster = false;
    public GameControll gameControll;

    // Use this for initialization
    void Awake () {
        spr = gameObject.GetComponent<SpriteRenderer>();
        index = ++increaseIndex;
        gameControll.indexGameObjectReflect.Add(index, gameObject);
    }

    public void SetMnoster(string mosterName)
    {
        Sprite sp = Resources.Load<Sprite>("monsters/" + mosterName);
        spr.sprite = sp;
    }

    public void OnMouseDown()
    {
        if (needClickMonster)
        {
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            spr.GetPropertyBlock(block);
            if (!isMonsterSelected)
            {
                block.SetFloat("_OffsetUV", 0.01f);
                isMonsterSelected = true;
                currentIndex = index;
                spr.SetPropertyBlock(block);
                return;
            }
            if (currentIndex == index)
            {
                block.SetFloat("_OffsetUV", 0.0f);
                isMonsterSelected = false;
                currentIndex = -1;
                spr.SetPropertyBlock(block);
            }
        }         
    }
}
