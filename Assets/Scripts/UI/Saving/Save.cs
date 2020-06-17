using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Save
{
    public int _money;
    public int _health;
    public int _wave;

    /*public int Money
    {
        get { return _money; }
        set { _money = value; }
    }
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    public int Wave
    {
        get { return _wave; }
        set { _wave = value; }
    }*/

    public Save(PlayerStats datatosave)
    {
        _money = PlayerStats.money;
        _health = PlayerStats.lives;
        _wave = PlayerStats.Waves;
        return;
    }
}
