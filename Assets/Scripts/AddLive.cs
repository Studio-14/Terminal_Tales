using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLive : MonoBehaviour
{
    //If a player enters the trigger, give a life
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefsManager.increaseLives(1);
        }
    }
}
