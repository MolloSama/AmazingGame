using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitStore : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("ready");
    }
}
