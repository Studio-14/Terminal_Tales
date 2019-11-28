using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    //Clicking play will set health if necessary, and start the game.
    public void PlayButtonClick()
    {
        if (PlayerPrefsManager.getLives() <= 0 && PlayerPrefsManager.getHealth() <= 0)
        {
            PlayerPrefsManager.setLives(3);
            PlayerPrefsManager.setHealth(100);
            //TODO: Load proper player location.
            PlayerPrefsManager.setLocation(new Vector3(0, 0, -1));
        }
        //TODO: Add tutorial and load if necessary
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
    }

    //Quits game when Exit is pressed
    public void QuitButton()
    {
        Application.Quit();
    }
}
