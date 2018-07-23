using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBorder : MonoBehaviour {
    public GameObject border;
    public static int currentIndex;
    public int index;
    

    // Use this for initialization
   void Awake() {
        currentIndex = 0;
    }

    private void OnMouseDown()
    {
        border.transform.DOMove(transform.position,0.6f);
        currentIndex = index;

    }
}
