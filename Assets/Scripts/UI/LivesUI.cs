using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(PlayerStats.lives, 0, Mathf.Infinity);
        livesText.text = PlayerStats.lives + " LIVES";
    }
}
