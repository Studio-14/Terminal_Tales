﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semicolon : MonoBehaviour
{

    //If the player jumps on top of the semicolon, kill the semicolon.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Foot Trigger")) 
        {
            if (other.GetComponentInParent<Rigidbody2D>().velocity.y < 0)
            {
                //TODO: Fix health taking from player later.
                PlayerPrefsManager.increaseHealth(5);
                GetComponentInParent<Enemy>().takeDamage(100);
            }
        }
    }
}
