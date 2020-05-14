using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public string nextLevel = "Lvl02";
    public int indexToUnlock = 2;

    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError(this + "couldn't find GameManager");
        }
    }

    public void Continue()
    {
        gameManager.Continue(nextLevel, indexToUnlock);
    }

    public void ToggleOptions()
    {
        gameManager.ToggleOptions();
    }

    public void Menu()
    {
        gameManager.Menu();
    }
}
