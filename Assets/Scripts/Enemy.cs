using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public int health = 100; //enemy's health

    public int amountOfDamage = 5; //damage that the enemy does

    private float hurtTimer; //starts enemy blinking
    
    private bool isHurt = false; //tracks whether the enemy is hurt
    
    //Boolean that determines if the player should lose health.
    [FormerlySerializedAs("canTakeDamage")] public bool playerCanTakeDamage = true;

    public bool canBeKilled = true; //true if this enemy can be defeated
    
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        //kills the enemy if applicable
        if (health <= 0)
        {
            DropItem[] di = GetComponents<DropItem>();
            for (int i = 0; i < di.Length; i++)
            {
                di[i].Drop();
            }
            Destroy(gameObject);
        }

        //damage blinking animation
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
        if (canBeKilled)
        {
            health -= damageToTake;
            isHurt = true;
        }
    }

    //If a player enters the trigger, take damage
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playerCanTakeDamage)
        {
            Player.takeDamage(amountOfDamage);
        }
    }
}
