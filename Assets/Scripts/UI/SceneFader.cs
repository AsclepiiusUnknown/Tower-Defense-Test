using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image fadeImg;
    public AnimationCurve fadeCurve;

    void Start()
    {
        StartCoroutine("FadeIn");
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    public void FadeToQuit()
    {
        StartCoroutine(FadeQuit());
        print("VOID");

    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            fadeImg.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            fadeImg.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    public IEnumerator FadeQuit()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            fadeImg.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        print("IE");


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

        print("End");

    }
}
