using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveControl : MonoBehaviour {

    public GameObject savePanePrefab;
    public Transform savePanePosition;
    public GameObject border;
    private int increaseIndex = 0;
    public Dictionary<int, SaveModel> saveNumberReflect = new Dictionary<int, SaveModel>();
    public Dictionary<int, GameObject> numberPaneReflect = new Dictionary<int, GameObject>();
    public string savePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\bmkz\\";

    // Use this for initialization
    void Start () {
        CreateDirectory(savePath);
        var files = Directory.GetFiles(savePath, "*.bin");
        foreach (string file in files)
        {
            saveNumberReflect.Add(int.Parse(file.Split('\\')[5].Split('.')[0]), null);
        }
        for(int i = 0; i < 4; ++i)
        {
            GameObject pane =
                Instantiate(savePanePrefab, savePanePosition.position + new Vector3(0, -i * 2f, 0), Quaternion.identity);
            pane.GetComponent<MoveBorder>().index = increaseIndex++;
            numberPaneReflect.Add(pane.GetComponent<MoveBorder>().index, pane);
            if (saveNumberReflect.ContainsKey(i))
            {
                SaveModel save = LoadSaveFile(i);
                saveNumberReflect[i] = save;
                SetPaneInfo(pane, save);
            }
            pane.GetComponent<MoveBorder>().border = border;
        }
    }

    public void SetPaneInfo(GameObject savePane, SaveModel save)
    {
        TextMesh time = savePane.transform.Find("time").GetComponent<TextMesh>();
        time.text = save.Time;
        TextMesh attribute = savePane.transform.Find("attribute").GetComponent<TextMesh>();
        attribute.text = "攻击 " + save.Kraken.AttactPower + "防御 " +
            save.Kraken.defensivePower + "血量 " + save.Kraken.BloodVolume;
        TextMesh mountain = savePane.transform.Find("mountain").GetComponent<TextMesh>();
        mountain.text = GlobalVariable.Mountains[save.CurrentScenes].name;
        SpriteRenderer spr = savePane.transform.Find("kraken").GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>("kraken/kraken");
    }

    SaveModel LoadSaveFile(int index)
    {
        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(savePath + index + ".bin",
            FileMode.Open);
        SaveModel save = (SaveModel)formatter.Deserialize(stream);
        stream.Close();
        return save;
    }

    void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            // Create the directory it does not exist.
            Directory.CreateDirectory(path);
        }
    }
}
