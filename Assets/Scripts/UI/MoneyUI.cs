using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI moneyText;
    public string formatCode = "F2";
    #endregion

    void Update()
    {
        //clamp the money between 0 and infinity
        Mathf.Clamp(PlayerStats.money, 0, Mathf.Infinity);
        //Display the money in the text element
        moneyText.text = "$" + PlayerStats.money.ToString(formatCode);
    }
}
