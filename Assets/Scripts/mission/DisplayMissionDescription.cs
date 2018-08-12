using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DisplayMissionDescription : MonoBehaviour {

    public GameObject missionDescriptionPrefab;
    private static List<GameObject> missionDescriptionObjects = new List<GameObject>();
    private TextMesh textMesh;
    private Transform missionParent;
    private Vector3 initPosition;

    // Use this for initialization
    void Start () {
        initPosition = transform.position;
        missionParent = GameObject.FindGameObjectWithTag("MissionButton").transform;
    }

    private void OnMouseEnter()
    {
        DestoryMissionDescription();
        LoadMissionDescription();
        initPosition = transform.position;
        transform.DOMove(initPosition + new Vector3(0.2f, 0, 0), 0.5f);
    }

    private void OnMouseExit()
    {
        transform.DOMove(initPosition, 0.5f);
    }

    void LoadMissionDescription()
    {
        List<string> descriptions = GlobalVariable.AllMissions[gameObject.name].Descriptions;
        for (int i = 0; i < GlobalVariable.AllMissions[gameObject.name].CurrentIndex; ++i)
        {
            GameObject missionDescription = Instantiate(missionDescriptionPrefab, 
                missionDescriptionPrefab.transform.position + new Vector3(0, -1f * i, 0), Quaternion.identity);
            missionDescription.transform.localScale = 
                new Vector3(missionDescription.transform.localScale.x * 0.8f, missionDescription.transform.localScale.y * 0.8f);

            missionDescription.transform.parent = missionParent;
            textMesh = missionDescription.GetComponent<TextMesh>();
            if (i == GlobalVariable.AllMissions[gameObject.name].CurrentIndex - 1)
            {
                textMesh.color = new Color(0, 0, 0);
            }
            else
            {
                textMesh.color = new Color(0.5f, 0.5f, 0.5f);
            }
            if(i < descriptions.Count)
            {
                textMesh.text = descriptions[i];
                missionDescriptionObjects.Add(missionDescription);
            }
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
