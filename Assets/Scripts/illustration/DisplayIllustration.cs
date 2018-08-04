using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DisplayIllustration : MonoBehaviour
{
    public IllustrationControl illustrationControl;

    private void OnMouseDown()
    {
        illustrationControl.currentIllustration = gameObject.name;
        illustrationControl.currentPage = 0;
        illustrationControl.LoadIllustration();
    }
}
    
