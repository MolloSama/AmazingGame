using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(SetGameOverBg());
	}

    IEnumerator SetGameOverBg()
    {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        DOTween.ToAlpha(() => spr.color, (x) => spr.color = x, 1, 2f);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("startMenu");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
