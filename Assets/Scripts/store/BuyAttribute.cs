using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAttribute : MonoBehaviour {

    private TextMesh detail;
    public TextMesh tip;
    // Use this for initialization
    void Start () {
        detail = GameObject.Find("detail").GetComponent<TextMesh>();
    }

    private void OnMouseDown()
    {
        int randomType = Random.Range(1, 4);
        int randomPercent = Random.Range(5, 11);
        switch (randomType)
        {
            case 1:
                float attact = GlobalVariable.kraKen.AttactPower;
                GlobalVariable.kraKen.AttactPower *= (1 + randomPercent / 100f);
                tip.text = "攻击力由" + attact + "提升至" + GlobalVariable.kraKen.AttactPower;
                break;
            case 2:
                float defend = GlobalVariable.kraKen.DefensivePower;
                GlobalVariable.kraKen.DefensivePower *= (1 + randomPercent / 100f);
                tip.text = "防御力由" + defend + "提升至" + GlobalVariable.kraKen.DefensivePower;
                break;
            case 3:
                int blood = GlobalVariable.kraKen.BloodVolume;
                GlobalVariable.kraKen.BloodVolume +=
                        System.Convert.ToInt32(GlobalVariable.kraKen.BloodVolume * (randomPercent / 100f));
                tip.text = "最大血量由" + blood + "提示至" + GlobalVariable.kraKen.BloodVolume;
                break;
        }
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        detail.text = "点击随机提升一项属性";
    }

    private void OnMouseExit()
    {
        detail.text = "";
    }
}
