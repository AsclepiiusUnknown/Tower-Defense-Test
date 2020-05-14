using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavesSurvived : MonoBehaviour
{
    public TextMeshProUGUI wavesText;

    void OnEnable()
    {
        //wavesText.text = PlayerStats.Waves.ToString();
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        wavesText.text = "0";
        int wave = 0;

        yield return new WaitForSeconds(.7f);

        while (wave < PlayerStats.Waves)
        {
            wave++;
            wavesText.text = wave.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }
}
