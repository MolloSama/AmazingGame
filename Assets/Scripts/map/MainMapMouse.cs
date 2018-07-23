using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMapMouse : MonoBehaviour {
    // Use this for initialization
    void Start () {
	}
	

    public void OnMouseUpAsButton()
    {
        SecondarySelect.SetScene(gameObject.name);
        while (true)
        {
            if (!SecondarySelect.setOver)
                continue;
            else
            {
                SceneManager.LoadScene("secondaryMap");
                break;
            }
        }
    }
}
public class MountainInformation
{
    public string serialnumber;
    public string name;
    public float x;
    public float y;
    public bool status;
    public int index;
    public MountainInformation(string a, string b, float c, float d, bool e, int f)
    {
        serialnumber = a;
        name = b;
        x = c;
        y = d;
        status = e;
        index = f;
    }
}
