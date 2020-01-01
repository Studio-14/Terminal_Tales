using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{

    [SerializeField] private bool isTutorial;
    //If the player enters the death trigger, it takes an entire life.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isTutorial)
            {
                PlayerPrefsManager.setHealth(0);
                other.gameObject.GetComponent<Player>().Lives();
            }
            else
            {
                other.gameObject.transform.position = new Vector3(18, 0, 0);
            }
        }
    }
}
