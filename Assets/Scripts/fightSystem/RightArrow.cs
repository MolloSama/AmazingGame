using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RightArrow : MonoBehaviour {

    public GameControll gameControll;
    private SpriteRenderer spr;
    int maxPage;
    bool canScroll = true;

    // Use this for initialization
    void Start () {
        spr = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        int count = GlobalVariable.BattleItems.Count;
        if(count != 0)
        {
            if (count >= 10)
            {
                maxPage = 5 + count - 10;
            }
            else if (count > 5)
            {
                maxPage = count - 5;
            }
            else
            {
                maxPage = 0;
            }
        }
        Material material;
        if (gameControll.currentPage >= maxPage)
        {
            material = Resources.Load<Material>("materials/SpriteGray");
            canScroll = false;
            spr.material = material;
        }
        else
        {
            material = new Material(Shader.Find("Sprites/Default"));
            canScroll = true;
        }
        spr.material = material;
    }

    private void OnMouseDown()
    {
        if (gameControll.isItemAnimationEnd && canScroll)
        {
            gameControll.isItemAnimationEnd = false;
            ++gameControll.currentPage;
            foreach (GameObject item in gameControll.itemSpriteReflect.Values)
            {
                item.transform.DOMove(item.transform.position +
                    new Vector3(-0.2f, 0, 0), 1f).OnComplete(() => gameControll.isItemAnimationEnd = true);
            }
        }
    }
}
