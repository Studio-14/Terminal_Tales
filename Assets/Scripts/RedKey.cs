using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : Key
{
    private bool hasTeleported = false; //tracks whether it teleported yet

    //location that the key will teleport to
    [SerializeField] private float newX = 0;
    [SerializeField] private float newY = 0;
    [SerializeField] private float newZ = 0;
    
    private float cooldownTimer = 0.1f; //minimum time between teleporting and picking up the key

    //updates cooldownTimer if applicable
    private void Update()
    {
        if (hasTeleported)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    //either teleports the red key or has the player pick it up
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasTeleported)
            {
                transform.position = new Vector3(newX, newY, newZ);
            }
            else if (hasTeleported && cooldownTimer <= 0f) 
            {
                PickUp();
            }

            hasTeleported = true;
        }
    }
}