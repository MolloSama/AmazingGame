using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {
    public GameObject circle;
    public static GameObject temp;
    private static readonly float[,] circlePosition = { { 1.66f, 0.27f },
                                                        { 1.35f, -1.3f },
                                                        { -0.65f, 0.52f},
                                                        { 0.68f, 1.63f},
                                                        { 4.6f, 1.07f},
                                                        { -2.71f, -2.2f},
                                                        { -5.85f, 2.92f},
                                                        { 2.14f, 2.49f},
                                                        { 4.41f, -1.22f},
                                                        {-4.21f, 0.59f },
                                                        {-2.4f, 2.2f },
                                                        {-1.32f, -1.36f },
                                                        { 6.05f, -1.78f},
                                                        {0.26f, -3.38f },
                                                        {-5.99f, -1.11f },
                                                        { 0.01f, 3.47f},
                                                        { -2.82f, -0.44f} };
    // Use this for initialization
    void Start () {
		
	}

    private void OnMouseEnter()
    {
        temp = Instantiate(circle, new Vector3(circlePosition[int.Parse(name) - 1, 0], circlePosition[int.Parse(name) - 1, 1]), Quaternion.identity);
    }
    private void OnMouseExit()
    {
        if (temp != null)
        {
            Destroy(temp);
            return;
        }
    }
    private void OnMouseUpAsButton()
    {
        Destroy(temp);
    }
}
