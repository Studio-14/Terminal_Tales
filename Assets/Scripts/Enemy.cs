using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //The health of the enemy variable
    public int health = 100;

    public int amountOfDamage = 5;

    //Checks if the enemy is dead. If so, destroy the game object.
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Take damage function
    public void takeDamage(int damageToTake)
    {
        health -= damageToTake;
    }

    //If a player enters the trigger, take damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.takeDamage(amountOfDamage);
        }
    }
}
