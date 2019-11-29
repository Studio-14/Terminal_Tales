﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Color32 inactiveColor = new Color32(0, 150, 0, 255);
    private Color activeColor = Color.cyan;
    private Checkpoint[] checkpoints; //array of all checkpoints that will be used to reset inactive checkpoints to default color

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    //When entering the trigger, save the player's location to PlayerPrefs.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Foot Trigger"))
        {
            PlayerPrefsManager.setLocation(transform.position);
            
            //handles checkpoint color changes
            for (int i = 0; i < checkpoints.Length; i++)
            {
                checkpoints[i].ResetColor();
            }
            sr.color = activeColor;
        }
    }

    //When exiting, change the color back to blue.
    //TODO: See if we should keep the changing colors.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Foot Trigger"))
        {
            //sr.color = inactiveColor; Do we actually want to change the color back?
        }
    }
    
    //Resets the checkpoint's color
    public void ResetColor()
    {
        sr.color = inactiveColor;
    }
}
