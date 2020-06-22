using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu, optionsMenu;

    // Start is called before the first frame update
    public void Paused()
    {
        //pause the game 
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    // Update is called once per frame
    public void UnPaused()
    {
        //unpause the game
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void Start()
    {
        UnPaused();
    }
    void TogglePause()
    {
        if (!isPaused)
        {
            Paused();
        }
        else
        {
            UnPaused();
        }
    }
    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!optionsMenu.activeSelf)
            {
                //toggle freely
                TogglePause();
            }
            else
            {
                pauseMenu.SetActive(true);
                optionsMenu.SetActive(false);
            }
        }
    }
}
