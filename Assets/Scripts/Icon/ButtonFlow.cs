using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFlow : MonoBehaviour {
    public int flag;
    // Use this for initialization
    private float baseX;
    private float baseY;
    private float baseZ;
    void Start () {
		
	}
    private void OnMouseEnter()
    {
        baseX = transform.localScale.x;
        baseY = transform.localScale.y;
        baseZ = transform.localScale.z;
        transform.localScale = new Vector3(baseX * 1.2f, baseY * 1.2f, baseZ);
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(baseX, baseY, baseZ);
    }
}
