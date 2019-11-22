using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    [SerializeField] private int platformSize = 1;

    [SerializeField] private float movementSpeed = 2.5f;

    private float distance = 0;

    //TODO set to correct number
    private const int distancePerPlatform = 33; //Distance to move across one platform

    private int goalDistance;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Makes the enemy move to the left
        movementSpeed *= -1;
        
        //Sets goalDistance
        setGoalDistance();
        
        //Finds the Rigidbody2d on the enemy
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        distance++;
        if (distance >= goalDistance)
        {
            movementSpeed *= -1; //Changes directions
            distance = 0;
        }
    }

    // Sets goalDistance
    void setGoalDistance()
    {
        goalDistance = distancePerPlatform * platformSize;
    }
}