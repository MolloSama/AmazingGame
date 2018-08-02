using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetLeadName : MonoBehaviour
{

    public InputField input;
    public void Click()
    {
        GlobalVariable.LeadName = input.text;
        LoadConversation.SetConversation("0-0-1", 0, "conversation", "");
        SceneManager.LoadScene("conversation");
    }
}
