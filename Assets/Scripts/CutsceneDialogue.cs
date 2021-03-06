﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutsceneDialogue : MonoBehaviour
{
    [SerializeField] private string[] strings = null;
    private string dialogueBuild;
    private TextMeshProUGUI text;
    private int i, j;

    private float delay;
    private bool shouldType = true;
    private int stringsLength;

    private CutsceneImages ci;

    //Gets text component and finds length of strings array.
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        stringsLength = strings.Length;
        ci = FindObjectOfType<CutsceneImages>();
    }

    // Update is called once per frame
    void Update()
    {
        //Delay timer for typing effect
        delay += Time.deltaTime;
        //When the boolean is true, start typing the dialogue when the delay is met
        if (shouldType)
        {
            if (delay >= 0.055f && j < strings[i].Length)
            {
                delay = 0f;
                dialogueBuild += strings[i][j];
                text.text = dialogueBuild;
                j++;
            }

            //Checks to see if the boolean should be made false
            shouldType = j < strings[i].Length;
        }
        else
        {
            //If the boolean is false, then wait a longer period of time before resetting for the next string.
            if (delay >= 5f && i < stringsLength - 1)
            {
                ci.ChangeImage();
                delay = 0f;
                shouldType = true;
                j = 0;
                dialogueBuild = "";
                text.text = dialogueBuild;
                i++;
            }
        }
    }
}