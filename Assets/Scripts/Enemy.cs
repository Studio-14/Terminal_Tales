using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //The health of the enemy variable
    public int health = 100;

    public int amountOfDamage = 5;

    private float hurtTimer;
    private bool isHurt = false;
    
    //Boolean that determines if the player should lose health.
    public bool canTakeDamage = true;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    //Checks if the enemy is dead. If so, destroy the game object.
    private void Update()
    {
        if (health <= 0)
        {
            DropItem[] di = GetComponents<DropItem>();
            for (int i = 0; i < di.Length; i++)
            {
                di[i].Drop();
            }
            
            Destroy(gameObject);
        }

        if (isHurt)
        {
            hurtTimer += Time.deltaTime;

            sr.enabled = !sr.enabled;

            if (hurtTimer >= 0.5f)
            {
                sr.enabled = true;
                
                isHurt = false;

                hurtTimer = 0;
            }
        }
    }

    //Take damage function
    public void takeDamage(int damageToTake)
    {
        health -= damageToTake;
        isHurt = true;
    }

    //If a player enters the trigger, take damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && canTakeDamage)
        {
            Player.takeDamage(amountOfDamage);
        }
    }
}
