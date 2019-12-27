using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject dropItem;
    
    [SerializeField] private float dropX;
    [SerializeField] private float dropY;
    [SerializeField] private float dropZ;
    
    //Drops an item
    public void Drop()
    {
        Instantiate(dropItem, new Vector3(dropX, dropY, dropZ), Quaternion.identity);
    }
}