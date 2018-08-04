using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfoDisplay : MonoBehaviour {
    public GameObject monsterInfoPrefab;
    public Transform infoPosition;
    public GameObject sceneName;

    // Use this for initialization
    void Start () {
        HashSet<string> monsters = new HashSet<string>(GlobalVariable.sceneMonsterNumber);
        int index = 0;
        foreach (string monsterNumber in monsters)
        {
            GameObject monsterInfo = Instantiate(monsterInfoPrefab,
                infoPosition.position + new Vector3(0, -1.5f * index, 0), Quaternion.identity);
            monsterInfo.transform.parent = transform;
            Monster monster = GlobalVariable.AllMonsters[monsterNumber];
            SpriteRenderer spr = monsterInfo.transform.Find("monsterImg").GetComponent<SpriteRenderer>();
            spr.sprite = Resources.Load<Sprite>("monsters/" + monster.Code);
            TextMesh name = monsterInfo.transform.Find("monsterName").GetComponent<TextMesh>();
            name.text = monster.Name;
            TextMesh description = monsterInfo.transform.Find("monsterDescription").GetComponent<TextMesh>();
            description.text = monster.Description;
            ++index;
            GlobalVariable.monsterIllustration[monster] = true;
        }
        sceneName.GetComponent<TextMesh>().text = GlobalVariable.Mountains[GlobalVariable.currentScene].name;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
