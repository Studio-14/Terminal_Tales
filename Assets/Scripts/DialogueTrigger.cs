using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private TextMeshProUGUI text;

    public string dialogue;

    private string dialogueBuild;

    private float dialogueTimer;

    private int dialogueLength;

    private int i;

    private bool shouldType;

    private void Start()
    {
        //Finds the dialogue text.
        text = GameObject.FindWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //To save resources, the dialogue timer should only run when the boolean is true.
        if (shouldType)
        {
            dialogueTimer += Time.deltaTime;
        }

        //Once triggered by the platform, start the typing effect by adding one letter at a time to another string
        //and displaying the work in progress string.
        if (shouldType && dialogueTimer >= 0.055f && i < dialogueLength)
        {
            dialogueBuild += dialogue[i];
            i++;
            dialogueTimer = 0f;
            text.text = dialogueBuild;
        }

        //Once the player leaves the platform, reset everything for the next platform.
        if (!shouldType && dialogueBuild != "")
        {
            dialogueBuild = "";
            i = 0;
            text.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the object that triggered the trigger is the player, start "typing" the dialogue text.
        if (other.gameObject.CompareTag("Player"))
        {
            shouldType = true;
            //Sets the length here in case the text is changed during game play.
            dialogueLength = dialogue.Length;
        }
    }

    //When leaving the trigger, set the text to nothing.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shouldType = false;
        }
    }
}
