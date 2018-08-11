using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour {

    public IllustrationControl illustrationControl;
    int count = 0;
    // Use this for initialization
    void Start () {
        switch (illustrationControl.currentIllustration)
        {
            case "card":
                count = GlobalVariable.cardIllustration.Count;
                break;
            case "item":
                count = GlobalVariable.itemIllustration.Count;
                break;
            case "monster":
                count = GlobalVariable.monsterIllustration.Count;
                break;
        }
    }

    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "prev":
                --illustrationControl.currentPage;
                if (illustrationControl.currentPage < 0)
                {
                    illustrationControl.currentPage = 0;
                }
                break;
            case "next":
                ++illustrationControl.currentPage;
                if (illustrationControl.currentPage > count / illustrationControl.maxPageCount)
                {
                    illustrationControl.currentPage = count / illustrationControl.maxPageCount;
                }
                break;
        }
        illustrationControl.LoadIllustration();
    }
}
