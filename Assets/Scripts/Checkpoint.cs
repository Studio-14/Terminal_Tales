using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    //When entering the trigger, save the player's location to PlayerPrefs.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Foot Trigger"))
        {
            PlayerPrefsManager.setLocation(transform.position);
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    //When exiting, change the color back to blue.
    //TODO: See if we should keep the changing colors.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Foot Trigger"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }
}
