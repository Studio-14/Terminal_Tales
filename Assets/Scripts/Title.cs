using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private string title = "";
    private TextMeshProUGUI text;

    //Get TextMeshPro from object
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    //Increments the title by a string every time when called. Used with animations.
    public void addCharacter(string character)
    {
        title += character;
        text.text = title;
    }
}
