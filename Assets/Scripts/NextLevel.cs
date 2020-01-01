using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    [SerializeField] private bool isTutorial;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isTutorial)
            {
                PlayerPrefsManager.setTutorialComplete(1);
            }
            
            //Loads the next scene in the array of scenes.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Tells the player that they are starting, which automatically finds the starting position.
            Player.isStarting = true;
            //Sets the health back to 100, as health doesn't carry in between levels.
            PlayerPrefsManager.setHealth(100);
        }
    }
}
