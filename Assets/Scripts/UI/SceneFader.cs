using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    #region Variables
    public Image fadeImg;
    public AnimationCurve fadeCurve;
    #endregion

    #region Setup
    void Start()
    {
        StartCoroutine("FadeIn");
    }
    #endregion

    #region Fading
    //used to fade into a scene
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //used to fade and quit
    public void FadeToQuit()
    {
        StartCoroutine(FadeQuit());
    }

    //Fade into the scene with the animation curve
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

    //Fade out of the scene into another with the curve
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

    //Fade to quit
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
        Application.Quit
#endif

        print("End");

    }
    #endregion
}
