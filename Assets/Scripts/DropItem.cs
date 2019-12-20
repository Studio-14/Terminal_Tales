using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public InventoryManager.Items itemTypes;
    
    //Drops an item
    public void Drop()
    {
        InventoryManager.AddItem((int)itemTypes);
    }
}