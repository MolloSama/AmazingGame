using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurning : MonoBehaviour {
    public DisplayMissionTitle displayMission;

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "prev":
                --displayMission.currentPage;
                if(displayMission.currentPage <= 0)
                {
                    displayMission.currentPage = 0;
                }
                break;
            case "next":
                ++displayMission.currentPage;
                if (displayMission.currentPage >= GlobalVariable.ExistingMissions.Count/displayMission.maxCount)
                {
                    displayMission.currentPage = GlobalVariable.ExistingMissions.Count / displayMission.maxCount;
                }
                break;
        }
        displayMission.LoadMissionTitle();
    }
}
