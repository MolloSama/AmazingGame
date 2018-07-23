using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{

    public Texture blackTexture;
    private float alpha = 1.0f;
    public float fadespeed = 0.2f;
    private int fadeDir = -1;
    public bool isFadeIn = true;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnGUI()
    {
        if (isFadeIn)
        {
            alpha += fadeDir * fadespeed * Time.deltaTime;
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
        }
    }

    public void BeginFade(int direction)
    {
        fadeDir = direction;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // do things after scene loaded.
        // Remove the delegate when no need.
        BeginFade(-1);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
