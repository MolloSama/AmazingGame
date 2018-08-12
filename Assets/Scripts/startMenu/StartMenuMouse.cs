using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuMouse : MonoBehaviour {

    // Use this for initialization
    void Start () {
        //WriteReflectTxt();
        //print(GetCallCount());
    }

    //void WriteReflectTxt()
    //{
    //    FileStream fs = new FileStream("D:/UnityProjects/AmazingGame/Assets/Resources/data/merge-reflect.txt", FileMode.Create);
    //    StreamWriter sw = new StreamWriter(fs);
    //    //开始写入
    //    for (int i = 1; i <= 32; ++i)
    //    {
    //        for (int j = 1; j <= 32; ++j)
    //        {
    //            for (int k = 1; k <= 32; ++k)
    //            {
    //                int randomNumber = Random.Range(1, 33);
    //                if(randomNumber <= 32 && randomNumber >= 22)
    //                {
    //                    if (!GlobalVariable.Chance(50))
    //                    {
    //                        randomNumber = Random.Range(1, 22);
    //                    }
    //                }
    //                string s = i.ToString("D" + 3) + "+" + j.ToString("D" + 3) + "+" + k.ToString("D" + 3) 
    //                    + "=" + randomNumber.ToString("D" + 3);
    //                sw.WriteLine(s);
    //            }
    //        }
    //    }
    //    //清空缓冲区
    //    sw.Flush();
    //    //关闭流
    //    sw.Close();
    //    fs.Close();
    //}

    //int GetCallCount()
    //{
    //    int count = 0;
    //    FileStream fs = new FileStream("D:/UnityProjects/AmazingGame/Assets/Resources/data/merge-reflect.txt", FileMode.Open);
    //    StreamReader reader = new StreamReader(fs);
    //    while (!reader.EndOfStream)
    //    {
    //        string s = reader.ReadLine();
    //        int number = int.Parse(s.Split('=')[1]);
    //        if(number >= 22)
    //        {
    //           ++count;
    //        }
    //    }
    //    //关闭流
    //    reader.Close();
    //    fs.Close();
    //    return count;
    //}

    //Mouse click
    public void OnMouseUpAsButton()
    {
        if (name.Equals("button1"))
        {
            SceneManager.LoadScene("setName");
        }
        if (name.Equals("button2"))
        {
            ReturnPre.preScene = "startMenu";
            SceneManager.LoadScene("accessProgress");
        }
        if (name.Equals("button3"))
        {
            SceneManager.LoadScene("illustration");
        }
        if (name.Equals("button4"))
        {
            DisplayTabloidText.type = "stuff";
            SceneManager.LoadScene("tabloid");
        }
    }
}
