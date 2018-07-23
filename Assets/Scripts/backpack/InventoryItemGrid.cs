using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemGrid : MonoBehaviour {
    private GameProp info = null;

    // Use this for initialization
    void Start () {

	}
    public void SetItem(GameProp t)
    {
        info = t;
        ChangeSprite();
        InventoryItem item = GetComponentInChildren<InventoryItem>();
        item.Item = t;
    }
    public void ChangeSprite()
    {
        if (info == null)
        {
            transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Objects/base");
        }
        else
        {
            transform.Find("skill").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("item/" + info.SerialNumber);
        }
    }


}
