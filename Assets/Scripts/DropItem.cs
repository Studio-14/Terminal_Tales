﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject dropItem = null; //the item to be dropped
    
    //Coordinates for the location of the item dropped
    [SerializeField] private float dropX = 0;
    [SerializeField] private float dropY = 0;
    [SerializeField] private float dropZ = 0;
    
    //Drops an item
    public void Drop()
    {
        Instantiate(dropItem, new Vector3(dropX, dropY, dropZ), Quaternion.identity);
    }
}