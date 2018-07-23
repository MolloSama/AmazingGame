using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveFile : MonoBehaviour {
    public SaveControl saveControl;
    private bool isStartMenu = false;
	// Use this for initialization
	void Start () {
        if (ReturnPre.preScene.Equals("startMenu"))
        {
            Destroy(gameObject.GetComponent<ButtonFlow>());
            SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
            spr.material = Resources.Load<Material>("materials/SpriteGray");
            isStartMenu = true;
        }
	}

    private void OnMouseDown()
    {
        if (!isStartMenu)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(saveControl.savePath+ MoveBorder.currentIndex + ".bin",
                FileMode.Create, FileAccess.Write);
            SaveModel save = new SaveModel();
            formatter.Serialize(stream, save);
            saveControl.SetPaneInfo(saveControl.numberPaneReflect[MoveBorder.currentIndex], save);
            stream.Close();
        }       
    }
}