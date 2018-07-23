using UnityEngine;

public class DisplayAttribute : MonoBehaviour {

    // Use this for initialization
    void Update()
    {
        TextMesh text = transform.GetComponent<TextMesh>();
        switch (gameObject.name)
        {
            case "attackValue":
                text.text = GlobalVariable.kraKen.AttactPower.ToString();
                break;
            case "defendValue":
                text.text = GlobalVariable.kraKen.DefensivePower.ToString();
                break;
            case "bloodValue":
                text.text = GlobalVariable.kraKen.BloodVolume.ToString();
                break;
        }
    }
}
