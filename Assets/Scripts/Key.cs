using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public InventoryManager.Items itemTypes;
    
    //Pick up the key
    public void PickUp()
    {
        InventoryManager.AddItem((int)itemTypes);
        Destroy(gameObject);
    }
    
    //This occurs when you hit the key
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        PickUp();
    }
}
