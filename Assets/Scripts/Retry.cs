﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }

    //When the retry button is clicked, go to the last level but with full health and back at the beginning
    public void ButtonClick()
    {
        PlayerPrefsManager.setLives(3);
        PlayerPrefsManager.setHealth(100);
        InventoryManager.ResetInventory();
        Cursor.visible = false;
        Player.isStarting = true;
        SceneManager.LoadScene(PlayerPrefsManager.getScene());
    }
    
    //Goes back to menu and deletes all game progress
    public void Replay()
    {
        InventoryManager.ResetInventory();
        Player.isStarting = true;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("0_Title");
    }
}
