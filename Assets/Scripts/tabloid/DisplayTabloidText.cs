using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DisplayTabloidText : MonoBehaviour {

    public GameObject textObject;
    public Transform endEndPosition;
    public Transform stuffEndPosition;
    public SpriteRenderer bg;
    public static string type;

	// Use this for initialization
	void Start () {
        if (type.Equals("end"))
        {
            textObject.GetComponent<TextMesh>().text = Resources.Load("data/end").ToString();
            textObject.transform.DOMove(endEndPosition.position, 16f).SetEase(Ease.Linear).OnComplete(() => SceneManager.LoadScene("startMenu"));
            bg.sprite = Resources.Load<Sprite>("tabloid-bg/end_bk");
        }
        if (type.Equals("stuff"))
        {
            textObject.GetComponent<TextMesh>().text = Resources.Load("data/stuff").ToString();
            textObject.transform.DOMove(stuffEndPosition.position, 16f).SetEase(Ease.Linear).OnComplete(() => SceneManager.LoadScene("startMenu"));
            bg.sprite = Resources.Load<Sprite>("tabloid-bg/stuff_bk");
        }
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("startMenu");
        }
    }
}
