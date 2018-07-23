using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LeftArrow : MonoBehaviour {

    public GameControll gameControll;
    private SpriteRenderer spr;
    bool canScroll;
	// Use this for initialization
	void Start () {
        spr = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Material material;
        if (gameControll.currentPage == 0)
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
            --gameControll.currentPage;
            foreach (GameObject item in gameControll.itemSpriteReflect.Values)
            {
                item.transform.DOMove(item.transform.position +
                    new Vector3(0.2f, 0, 0), 1f).OnComplete(() => gameControll.isItemAnimationEnd = true);
            }
        }
        
    }
}
