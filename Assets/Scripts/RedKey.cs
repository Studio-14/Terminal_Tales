using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : Key
{
    private bool hasTeleported = false;

    [SerializeField] private float newX = 0;
    [SerializeField] private float newY = 0;
    [SerializeField] private float newZ = 0;
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTeleported)
        {
            if (other.CompareTag("Player"))
            {
                transform.position = new Vector3(newX, newY, newZ);
                hasTeleported = true;
            }
        }
        else
        {
            PickUp();
        }
    }
}