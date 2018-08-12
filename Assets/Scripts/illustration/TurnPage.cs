using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour {

    public IllustrationControl illustrationControl;
    private int count;
    // Use this for initialization
    void Start () {
        count = 0;
    }

    private void OnMouseDown()
    {
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
