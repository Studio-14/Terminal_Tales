using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class InventoryManager : MonoBehaviour
{
    
    public enum Items
    {
        RedKey,
        GreenKey,
        BlueKey
    }

    public const int NumItems = 3;
    
    private static  bool[] inventory = new bool[3];
    
    //Translates savedData to inventory variables
    static void DecodeInventory(string savedData)
    {

        for (int i = 0; i < NumItems; i++)
        {
            inventory[i] = (savedData[i] == '1');
        }
    }
    
    //Saves inventory to PlayerPrefs
    static void SaveInventory()
    {

        string savedData = "";
        for (int i = 0; i < NumItems; i++)
        {
            char latestChar = (inventory[i]) ? '1' : '0';
            savedData += latestChar;
        } 
        
        PlayerPrefsManager.setInventory(savedData);
    }

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("inventory"))
        {
            string savedData = PlayerPrefsManager.getInventory();
            DecodeInventory(savedData);
        }
        else
        {
            ResetInventory();
        }

    }
    
    //Adds an item
    public static void AddItem(int itemType)
    {
        inventory[itemType] = true;

        SaveInventory();
    }
    
    //Reset inventory
    public static void ResetInventory()
    {
        string savedData = "";
        for (int i = 0; i < NumItems; i++)
        {
            savedData += '0';
        }
        
        DecodeInventory(savedData);
        
        SaveInventory();
    }

    //Determines whether player has all three keys
    public static bool hasAllKeys()
    {
        for (int i = 0; i < 2; i++)
        {
            if (!inventory[i])
            {
                return false;
            }
        }

        return true;
    }
}
