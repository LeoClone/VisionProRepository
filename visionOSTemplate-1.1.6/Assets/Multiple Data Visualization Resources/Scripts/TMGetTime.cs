using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMGetTime : MonoBehaviour
{
    public TextMeshProUGUI text;

    public bool isHMSorYMD = true;
    
    void Update()
    {
        if(isHMSorYMD)
        //text.text = System.DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        text.text = System.DateTime.Now.ToString("HH:mm:ss");
        else
            text.text = System.DateTime.Now.ToString("yyyy/MM/dd");

    }
}
