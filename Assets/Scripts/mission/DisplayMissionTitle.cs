using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMissionTitle : MonoBehaviour {

    public GameObject missionTilePrefab;
    public int currentPage;
    public int maxCount;
    private List<GameObject> missionTitleObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
        GlobalVariable.ExistingMissions = new List<Mission>(GlobalVariable.AllMissions.Values);
        currentPage = 0;
        maxCount = 7;
        LoadMissionTitle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMissionTitle()
    {
        DestoryMissionTitle();
        if (GlobalVariable.ExistingMissions.Count- currentPage * maxCount >= maxCount)
        {
            LoadMissionTitle(maxCount);
        }
        else
        {
            LoadMissionTitle(GlobalVariable.ExistingMissions.Count - currentPage * maxCount);
        }
    }

    void LoadMissionTitle(int count)
    {
        for(int i= 0; i < count; ++i)
        {
            GameObject missionTitle = Instantiate(missionTilePrefab, missionTilePrefab.transform.position + 
                new Vector3(0, -1.25f * i, 0), Quaternion.identity);
            missionTitle.GetComponent<TextMesh>().text = GlobalVariable.ExistingMissions[i + currentPage * maxCount].Title;
            missionTitle.name = GlobalVariable.ExistingMissions[i + currentPage * maxCount].SerialNumber;
            missionTitleObjects.Add(missionTitle);
        }
    }

    void DestoryMissionTitle()
    {
        foreach(GameObject title in missionTitleObjects)
        {
            Destroy(title);
        }
        missionTitleObjects.Clear();
    }
}
