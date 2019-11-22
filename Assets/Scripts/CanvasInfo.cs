using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    private TextMeshProUGUI[] texts;
    
    //Gets TextMeshPro from the game objects referenced by the canvas.
    private void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
    }

    //Every frame, display the accurate count of lives and health.
    private void LateUpdate()
    {
        texts[0].text = "Health: " + PlayerPrefsManager.getHealth();
        texts[1].text = "Lives " + PlayerPrefsManager.getLives();
    }
}
