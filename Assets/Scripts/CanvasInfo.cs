using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    private TextMeshProUGUI[] texts;
    private Color good = new Color(0, 200, 0), medium = new Color(255, 255, 0), bad = new Color(255, 0, 0), black = Color.black;

    [SerializeField] private Alfred boss = null;

    //Private timer for when the health flashes
    private float flashTimer;

    //How long the flash should last.
    public float flashDelay = 0.25f;
    
    //Enemy component
    private Enemy enemyScript;
    
    //RectTransform of boss bar
    private RectTransform bossbar;
    
    //Gets TextMeshPro from the game objects referenced by the canvas.
    private void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();

        if (boss != null)
        {
            enemyScript = boss.GetComponent<Enemy>();
            bossbar = GetComponentInChildren<RectTransform>();
        }
    }

    //Every frame, display the accurate count of lives and health and boss health bar.
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
        else if (PlayerPrefsManager.getHealth() > 10 && PlayerPrefsManager.getHealth() <= 25)
        {
            texts[0].color = bad;
        }
        else
        {
            //Flash the health because it's critically low
            CriticalHealth();
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
        
        if (boss != null)
        {
            ChangeBossBar();
        }
    }

    void CriticalHealth()
    {
        //Increase the health by real time.
        flashTimer += Time.deltaTime;

        //Set the color of the health text based off the previous color.
        if (flashTimer >= flashDelay)
        {
            texts[0].color = texts[0].color == bad ? black : bad;
            flashTimer = 0f;
        }
    }

    //Updates boss bar
    void ChangeBossBar()
    {
        float percentHealth = (enemyScript.health * 1f) / boss.baseHealth;
        
        //Calculate size of bar
        float newWidth = percentHealth * 790;
        bossbar.rect.Set(bossbar.rect.x, bossbar.rect.y, newWidth, bossbar.rect.height);
        
        Debug.Log(bossbar.rect.width);
    }
}
