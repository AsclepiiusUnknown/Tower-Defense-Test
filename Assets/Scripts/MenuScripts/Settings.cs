using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle fullscreen;
    public float volume;
    public Toggle mute;
    public AudioSource music;
    public Slider volSlider;

    public void Start()
    {
        //The main set of things in the options menu you need throughout the game
        fullscreen.isOn = IntToBool(PlayerPrefs.GetInt("FS"));
        music.volume = PlayerPrefs.GetFloat("Volume");
        music.mute = IntToBool(PlayerPrefs.GetInt("Mute"));
        mute.isOn = music.mute;
        volSlider.value = music.volume;
        setFullScreen();
    }

    public void Volume()
    {
        //for the volume slider
        volume = volSlider.value;
        PlayerPrefs.SetFloat("Volume", volume);
        music.volume = volume;
    }

    public void Mute()
    {
        //for mute
        PlayerPrefs.SetInt("Mute", BoolToInt(mute.isOn));
        music.mute = mute.isOn;
    }

    public int BoolToInt(bool x)
    {
        if (x)
        {
            return 1;
        }
        return 0;
    }

    public bool IntToBool(int x)
    {
        if (x == 0)
        {
            return false;
        }
        return true;
    }

    public void setFullScreen()
    {
        //for fullscreen
        PlayerPrefs.SetInt("FS", BoolToInt(fullscreen.isOn));
        if (fullscreen.isOn)
        {
            Screen.fullScreen = true;
            //making sure i know if the fullscreen toggle works
            Debug.Log("help");
        }
        else
        {
            
            Screen.fullScreen = false;
        }
    }

}
