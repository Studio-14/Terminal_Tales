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
    private Music music;

    private void Start()
    {
        //Gets the canvas group component.
        canvasGroup = GetComponent<CanvasGroup>();
        player = FindObjectOfType<Player>();
        music = FindObjectOfType<Music>();

        //Ensures that audio continues to work when changing scenes while paused.
        if (!isPaused && canvasGroup.alpha <= 0)
        {
            changeMenu(1, 1, 0, false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //If the player presses escape, the game pauses or resumes
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        //Sets the isPaused variable based on the visibility of the pause menu.
        isPaused = canvasGroup.alpha <= 0;

        //If the game is paused, disable time.
        if (isPaused)
        {
            changeMenu(0, 0, 1, true);
        }
        //If the game is not paused, keep time running.
        else if (!isPaused)
        {
            changeMenu(1, 1, 0, false);
        }
    }

    //Function that sets values of variables based on how it was called.
    private void changeMenu(int volume, int timeScale, int alpha, bool bools)
    {
        AudioListener.volume = volume;
        Time.timeScale = timeScale;
        canvasGroup.alpha = alpha;
        canvasGroup.interactable = bools;
        isPaused = bools;
        Cursor.visible = bools;

        if (bools)
            music.GetComponent<AudioSource>().Pause();
        else
            music.GetComponent<AudioSource>().Play();
    }

    //If the player wishes to go back to the main menu, reenable time and go to the main menu scene.
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        music.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("0_Title");
    }

    //If the player wishes to quit the game, force quit the game.
    public void ExitGame()
    {
        Application.Quit();
    }
}
