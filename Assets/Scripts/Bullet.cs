using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    
    [SerializeField] private int damage = 5;

    [SerializeField] private bool usesEnemyDamage = false;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    //If the bullet hits an enemy, take damage on the enemy.
    private void OnTriggerEnter2D(Collider2D other)
    {    
        //Destroy the bullet when it hits most things
        if (!other.gameObject.GetComponent<Checkpoint>() && !other.gameObject.GetComponent<Key>() &&
            !other.gameObject.GetComponent<RedKey>() && !other.gameObject.GetComponent<HealthPack>() &&
            !other.GetComponent<DialogueTrigger>() && !other.gameObject.GetComponent<Bullet>() ||  (other.gameObject.GetComponent<Bullet>() && !usesEnemyDamage)) 
        {
            Destroy(gameObject);
        }

        //Deals damage to enemies
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(damage);
        }

        //damages fragile walls
        if (other.gameObject.GetComponent<FragileWall>())
        {
            other.gameObject.GetComponent<FragileWall>().takeHit();
        }
        
        
    }
}
