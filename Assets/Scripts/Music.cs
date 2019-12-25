using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    //Sets volume of music
    private void Start()
    {
        audioMixer.SetFloat("musicVolume", PlayerPrefsManager.getVolume());
    }
}
