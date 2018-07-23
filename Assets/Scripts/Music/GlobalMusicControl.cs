using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicControl : MonoBehaviour
{

    public GameObject globalUIMusic;
    private static GameObject preMusic;
    GameObject MyUIMusic;

    private void Start()
    {
        
        if (preMusic == null)
        {
            MyUIMusic = Instantiate(globalUIMusic);
            preMusic = MyUIMusic;
        }
        if (!preMusic.name.Replace("(Clone)", "").Equals(globalUIMusic.name))
        {
            Destroy(preMusic);
            MyUIMusic = Instantiate(globalUIMusic);
            preMusic = MyUIMusic;
        }
    }
}
