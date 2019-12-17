using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    [SerializeField]
    private float newX, newY, newZ;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Foot Trigger"))
        {
            //Loads the next scene in the array of scenes.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Sets the location to what is stored in the editor.
            PlayerPrefsManager.setLocation(new Vector3(newX, newY, newZ));
            //Sets the health back to 100, as health doesn't carry in between levels.
            PlayerPrefsManager.setHealth(100);
        }
    }
}
