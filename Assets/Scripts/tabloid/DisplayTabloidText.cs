using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DisplayTabloidText : MonoBehaviour {

    public GameObject textObject;
    public Transform endPosition;
	// Use this for initialization
	void Start () {
        textObject.GetComponent<TextMesh>().text = Resources.Load("data/tabloidText").ToString() ;
        textObject.transform.DOMove(endPosition.position, 10f).SetEase(Ease.Linear).OnComplete(()=>SceneManager.LoadScene("startMenu"));
	}
}
