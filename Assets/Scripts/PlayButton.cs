using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PlayButton : MonoBehaviour
{
    //Clicking play will set health if necessary, and start the game.
    public void PlayButtonClick()
    {
        if (PlayerPrefsManager.getLives() <= 0 && PlayerPrefsManager.getHealth() <= 0)
        {
            PlayerPrefsManager.setLives(3);
            PlayerPrefsManager.setHealth(100);
            Player.isStarting = true;
        }
        //Checks if tutorial has been completed. If not, show cutscene and tutorial.
        if (PlayerPrefsManager.getTutorialComplete() == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //Otherwise, load the last level the player was on.
        else
        {
            SceneManager.LoadScene(PlayerPrefsManager.getScene());
        }

        Cursor.visible = false;
    }

    //Loads settings scene
    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    //Quits game when Exit is pressed
    public void QuitButton()
    {
        Application.Quit();
    }
}
