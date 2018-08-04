using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStart : MonoBehaviour {

    private void OnMouseDown()
    {
        SceneManager.LoadScene("startMenu");
    }
}
