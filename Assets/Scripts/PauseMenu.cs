using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool isPaused;

    private Player player;

    private Vector3 playerPos;

    private void Start()
    {
        //Gets the canvas group component.
        canvasGroup = GetComponent<CanvasGroup>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player presses escape, the game pauses or resumes
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        //If the alpha of the group is 0 (or disabled), enable the pause menu and disable gameplay.
        if (canvasGroup.alpha <= 0)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            isPaused = true;
            Cursor.visible = true;
            AudioListener.volume = 0;
        }
        //If the alpha of the group is 1 (or enabled), disable the pause menu and reenable gameplay.
        else if (canvasGroup.alpha >= 1)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            isPaused = false;
            Cursor.visible = false;
            AudioListener.volume = 1;
        }

        //If the game is paused, disable time.
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        //If the game is not paused, keep time running.
        else if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }

    //If the player wishes to go back to the main menu, reenable time and go to the main menu scene.
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        PlayerPrefsManager.setLocation(player.transform.position);
        SceneManager.LoadScene("0_Title");
    }

    //If the player wishes to quit the game, force quit the game.
    public void ExitGame()
    {
        PlayerPrefsManager.setLocation(player.transform.position);
        Application.Quit();
    }
}
