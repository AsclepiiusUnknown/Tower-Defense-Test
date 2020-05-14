using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public string levelToLoad = "MainMenu";

    public SceneFader sceneFader;

    private bool nowCounting = false;
    public float holdTimeInSecs = 3f;
    private float timer = 0f;

    void Awake()
    {
        timer = holdTimeInSecs;
    }

    void Start()
    {
        sceneFader.gameObject.SetActive(true);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timer = holdTimeInSecs;
            print("Start: " + timer);
            nowCounting = true;
        }

        if (nowCounting)
        {
            print("During: " + timer);
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            print("End: " + timer);
            nowCounting = false;
            Quit();
        }
    }

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        //print("Quitting...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit
#endif
    }
}
