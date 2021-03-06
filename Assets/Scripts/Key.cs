﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public InventoryManager.Items itemTypes;

    private void Start()
    {
        //If the item does exist in the inventory, then destroy it.
        if (PlayerPrefsManager.getInventory()[(int)itemTypes] == '1')
        {
            Destroy(gameObject);
        }
    }

    //Pick up the key
    public void PickUp()
    {
        InventoryManager.AddItem((int)itemTypes);
        Destroy(gameObject);
    }
    
    //This occurs when you hit the key
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }
}
