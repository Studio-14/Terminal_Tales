using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    //If the player enters the death trigger, it takes an entire life.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefsManager.setHealth(0);
            other.gameObject.GetComponent<Player>().Lives();
        }
    }
}
