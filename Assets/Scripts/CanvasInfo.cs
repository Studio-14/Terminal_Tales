using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    private TextMeshProUGUI[] texts;
    private Color good = new Color(0, 200, 0), medium = new Color(255, 255, 0), bad = new Color(255, 0, 0);
    
    //Gets TextMeshPro from the game objects referenced by the canvas.
    private void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
    }

    //Every frame, display the accurate count of lives and health.
    private void LateUpdate()
    {
        //If statements that change the color of the health and lives text based off the player's health and lives left.
        if (PlayerPrefsManager.getHealth() > 75)
        {
            texts[0].color = good;
        }
        else if (PlayerPrefsManager.getHealth() > 25 && PlayerPrefsManager.getHealth() <= 75)
        {
            texts[0].color = medium;
        }
        else
        {
            texts[0].color = bad;
        }

        if (PlayerPrefsManager.getLives() >= 3)
        {
            texts[1].color = good;
        }
        else if (PlayerPrefsManager.getLives() == 2)
        {
            texts[1].color = medium;
        }
        else
        {
            texts[1].color = bad;
        }
        texts[0].text = "Health: " + PlayerPrefsManager.getHealth();
        texts[1].text = "Lives: " + PlayerPrefsManager.getLives();
    }
}
