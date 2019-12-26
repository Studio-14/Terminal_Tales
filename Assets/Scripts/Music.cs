using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    public AudioMixer audioMixer;
    private AudioSource audioSource;
    
    //Sets volume of music
    private void Start()
    {
        audioMixer.SetFloat("musicVolume", PlayerPrefsManager.getVolume());
        audioSource = GetComponent<AudioSource>();
    }

    //Speed up music if the health is critical
    private void Update()
    {
        audioSource.pitch = PlayerPrefsManager.getHealth() <= 10 ? 1.15f : 1f;
    }
}
