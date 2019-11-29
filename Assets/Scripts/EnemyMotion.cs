using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField] private int platformSize = 1;

    [SerializeField] private float movementSpeed = 2.5f;

    private const float distancePerPlatform = 0.65f; //Distance to move across one platform old:0.6

    private double goalTime;

    private float moveTimer;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //Makes the enemy move to the left
        movementSpeed *= -1;
        
        //Sets goalTime
        setGoalTime();
        
        //Finds the Rigidbody2d on the enemy
        rb = GetComponent<Rigidbody2D>();
        
        //Finds the enemy's sprite rendered
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveTimer += Time.deltaTime;
        
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        if (moveTimer >= goalTime)
        {
            movementSpeed *= -1; //Changes directions
            sr.flipX = !sr.flipX; //Flips sprite
            moveTimer = 0;
        }
    }

    // Sets goalTime
    void setGoalTime()
    {
        goalTime = distancePerPlatform * platformSize * (2.5 / movementSpeed);
        if (goalTime < 0)
        {
            goalTime *= -1;
        }
    }
}