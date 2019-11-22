using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    
    public GameObject healthText, livesText;

    private TextMeshProUGUI health, lives;
    

    //Gets TextMeshPro from the game objects referenced by the canvas.
    private void Start()
    {
        health = healthText.GetComponent<TextMeshProUGUI>();
        lives = livesText.GetComponent<TextMeshProUGUI>();
    }

    //Every frame, display the accurate count of lives and health.
    private void LateUpdate()
    {
        health.text = "Health: " + PlayerPrefsManager.getHealth();
        lives.text = "Lives " + PlayerPrefsManager.getLives();
    }
}
