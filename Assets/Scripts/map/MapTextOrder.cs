﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTextOrder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MeshRenderer myMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        myMeshRenderer.sortingLayerName = "foreground";
        myMeshRenderer.sortingOrder = 4;
    }
}
