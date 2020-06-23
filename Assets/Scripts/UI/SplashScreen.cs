using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SplashScreen : MonoBehaviour
{
    public string sceneToLoad = "MainMenu";

    public SceneFader sceneFader;

    private bool canCount = true;
    private bool doOnce = false;
    public float holdTimeInSecs = 3f;
    private float timer;

    public TextMeshProUGUI display;

    void Awake()
    {
        timer = holdTimeInSecs;
    }

    void Start()
    {
        sceneFader.gameObject.SetActive(true);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);

        StartCoroutine(FadeThrough());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
            print("playerPrefs cleaned");
        }

        if (timer >= 0.0f)
        {
            timer -= Time.deltaTime;
            display.text = timer.ToString("F2");
        }
        else if (timer <= 0.0f)
        {
            canCount = false;
            doOnce = true;
            timer = 0.00f;
            display.text = timer.ToString("F2");
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public IEnumerator FadeThrough()
    {
        yield return new WaitForSeconds(5);
        sceneFader.FadeTo(sceneToLoad);
    }
}
