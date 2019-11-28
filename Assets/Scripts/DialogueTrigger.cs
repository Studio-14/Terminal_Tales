using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private TextMeshProUGUI text;

    public string dialogue;

    private void Start()
    {
        //Finds the dialogue text.
        text = GameObject.FindWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the object that triggered the trigger is the player, show the dialogue text.
        if (other.gameObject.CompareTag("Foot Trigger") || other.gameObject.CompareTag("Player"))
        {
            text.text = dialogue;
        }
    }

    //When leaving the trigger, set the text to nothing.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Foot Trigger") || other.gameObject.CompareTag("Player"))
        {
            text.text = "";
        }
    }
}
