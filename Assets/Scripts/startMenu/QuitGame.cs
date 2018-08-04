using UnityEngine;

public class QuitGame : MonoBehaviour {

    private string savePath;
    // Use this for initialization
    void Start () {
    }

    private void OnMouseDown()
    {
        Application.Quit();
    }
}
