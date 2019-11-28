using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Color32 exitColor = new Color32(0, 150, 0, 255);

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    //When entering the trigger, save the player's location to PlayerPrefs.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Foot Trigger"))
        {
            PlayerPrefsManager.setLocation(transform.position);
            sr.color = Color.cyan;
        }
    }

    //When exiting, change the color back to blue.
    //TODO: See if we should keep the changing colors.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Foot Trigger"))
        {
            sr.color = exitColor;
        }
    }
}
