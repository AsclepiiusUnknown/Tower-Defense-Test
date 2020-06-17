using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SavingData : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetInt("Money", 400);
        PlayerPrefs.SetInt("Health", 3);
        PlayerPrefs.SetInt("Wave", 1);
    }


}
