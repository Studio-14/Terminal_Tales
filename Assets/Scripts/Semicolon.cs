using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semicolon : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    //If the player jumps on top of the semicolon, kill the semicolon.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Foot Trigger") && (other.GetComponentInParent<Rigidbody2D>().velocity.y < 0))
        {
            //Disables the enemy from taking damage temporarily.
            enemy.canTakeDamage = false;
            
            //Deals 100 damage
            enemy.takeDamage(100);
        }
    }
}
