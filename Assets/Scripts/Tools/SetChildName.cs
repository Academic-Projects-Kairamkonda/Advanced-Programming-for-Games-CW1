using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetChildName : MonoBehaviour
{
    public string typeImage="Image";
    public string typeButton = "Button";
    public string typeText = "Text";

    private void OnValidate()
    {
        this.gameObject.transform.GetChild(0).name = this.gameObject.name+typeText;
        this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=this.gameObject.name;
        this.gameObject.transform.GetChild(1).name = this.gameObject.name + typeButton;
    }
}
