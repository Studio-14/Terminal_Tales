using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private string title = "";
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void addCharacter(string character)
    {
        title += character;
        text.text = title;
    }
}
