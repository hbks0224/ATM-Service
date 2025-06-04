using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NowCash : MonoBehaviour
{
    public int nowmoney = 0;

    string nowmoneyStr;
    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        nowmoneyStr = nowmoney.ToString("#,##0");
        textMeshProUGUI.text = nowmoneyStr;
    }




}
