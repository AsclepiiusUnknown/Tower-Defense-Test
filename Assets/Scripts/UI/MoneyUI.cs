using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public string formatCode = "F2";

    void Update()
    {
        Mathf.Clamp(PlayerStats.money, 0, Mathf.Infinity);
        moneyText.text = "$" + PlayerStats.money.ToString(formatCode);
    }
}
