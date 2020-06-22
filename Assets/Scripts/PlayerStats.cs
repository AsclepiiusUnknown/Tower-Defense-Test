using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Variables
    public static int money;
    public int startMoney = 400;

    public static int lives;
    public int startLives = 20;

    public static int Waves;
    #endregion

    #region Setup
    void Start()
    {
        money = startMoney;
        lives = startLives;

        Waves = 0;
    }
    #endregion

    #region Lives
    public static void ReduceLives(int amount)
    {
        lives -= amount;
    }

    public static void IncreaseLives(int amount)
    {
        lives += amount;
    }
    #endregion

    #region Money
    public static void ReduceMoney(int amount)
    {
        money -= amount;
    }

    public static void IncreaseMoney(int amount)
    {
        money += amount;
    }
    #endregion
}
