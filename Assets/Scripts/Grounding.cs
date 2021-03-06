﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounding : MonoBehaviour
{
    //If the player is on top of the platform, ground the player
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().Ground();
        }
    }
}
