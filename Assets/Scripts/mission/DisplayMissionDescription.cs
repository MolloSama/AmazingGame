using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMissionDescription : MonoBehaviour {

    public GameObject missionDescriptionPrefab;
    private static List<GameObject> missionDescriptionObjects = new List<GameObject>();
    private TextMesh textMesh;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        DestoryMissionDescription();
        LoadMissionDescription();
    }

    void LoadMissionDescription()
    {
        List<string> descriptions = GlobalVariable.AllMissions[gameObject.name].Descriptions;
        for (int i = 0; i < GlobalVariable.AllMissions[gameObject.name].CurrentIndex; ++i)
        {
            GameObject missionDescription = Instantiate(missionDescriptionPrefab, 
                missionDescriptionPrefab.transform.position + new Vector3(0, -1f * i, 0), Quaternion.identity);
            textMesh = missionDescription.GetComponent<TextMesh>();
            if (i == GlobalVariable.AllMissions[gameObject.name].CurrentIndex - 1)
            {
                textMesh.color = new Color(0, 0, 0);
            }
            else
            {
                textMesh.color = new Color(0.5f, 0.5f, 0.5f);
            }
            textMesh.text = descriptions[i];
            missionDescriptionObjects.Add(missionDescription);
        }
    }

    void DestoryMissionDescription()
    {
        foreach (GameObject description in missionDescriptionObjects)
        {
            Destroy(description);
        }
        missionDescriptionObjects.Clear();
    }
}
