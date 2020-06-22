using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI livesText;
    #endregion

    // clamp the lives between 0 and infinity and then display it with the text element
    void Update()
    {
        Mathf.Clamp(PlayerStats.lives, 0, Mathf.Infinity);
        livesText.text = PlayerStats.lives + " LIVES";
    }
}
