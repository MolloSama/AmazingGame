using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMissionTitle : MonoBehaviour {

    public GameObject missionTilePrefab;
    public int currentPage;
    public int maxCount;
    private List<GameObject> missionTitleObjects = new List<GameObject>();
    private Transform missionParent;
    public static DisplayMissionTitle _instance;

    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
	}

    public void AnShow()
    {
        currentPage = 0;
        maxCount = 7;
        missionParent = GameObject.FindGameObjectWithTag("MissionButton").transform;
        LoadMissionTitle();
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
            missionTitle.transform.parent = missionParent;
            missionTitle.transform.Find("missionTitleText").GetComponent<TextMesh>().text 
                = GlobalVariable.ExistingMissions[i + currentPage * maxCount].Title;
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
