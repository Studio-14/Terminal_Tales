using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Image[] keys;
    

    // Update is called once per frame
    void LateUpdate()
    {
        //Searches to see if a key image should be enabled by looking at the current inventory.
        for (int i = 0; i < 3; i++)
        {
            keys[i].GetComponent<Image>().enabled = PlayerPrefsManager.getInventory()[i] == '1';
        }
    }
}
