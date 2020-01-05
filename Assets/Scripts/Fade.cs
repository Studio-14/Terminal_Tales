using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    void Update()
    {
        //Allows skipping of cutscene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadNextScene();
        }
    }
    
    //Loads next scene. Triggers by animation.
    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.isStarting = true;
    }
}
