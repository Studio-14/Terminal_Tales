using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Gateway : MonoBehaviour
{
    //Opens if the player has all keys
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (InventoryManager.hasAllKeys())
        {
            Destroy(gameObject);
        }
    }
}
