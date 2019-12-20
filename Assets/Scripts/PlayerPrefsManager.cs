using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string PLAYER_HEALTH = "player_health";

    private const string PLAYER_LIVES = "player_lives";

    private const string CURRENT_SCENE = "current_scene";

    private const string PLAYER_X = "player_x";

    private const string PLAYER_Y = "player_y";

    private const string PLAYER_Z = "player_z";

    private const string INVENTORY = "inventory";

    //Retrieves lives from PlayerPrefs.
    public static int getLives()
    { 
        return PlayerPrefs.GetInt(PLAYER_LIVES);
    }

    //Sets lives in PlayerPrefs to a fixed amount (Useful for resetting game)
    public static void setLives(int amount)
    {
        PlayerPrefs.SetInt(PLAYER_LIVES, amount);
        setHealth(100);
    }
    
    //Decrease lives such as damage
    public static void decreaseLives(int amount)
    {
        PlayerPrefs.SetInt(PLAYER_LIVES, getLives() - amount);
        setHealth(100);
    }

    //Increase lives, such as health packs.
    public static void increaseLives(int amount)
    {
        PlayerPrefs.SetInt(PLAYER_LIVES, getLives() + amount);
    }

    //Get health from PlayerPrefs.
    public static int getHealth()
    {
        return PlayerPrefs.GetInt(PLAYER_HEALTH);
    }

    //Sets health to fixed amount, such as resetting the game.
    public static void setHealth(int amount)
    {
        PlayerPrefs.SetInt(PLAYER_HEALTH, amount);
    }

    //Decreases health, such as enemy attacks.
    public static void decreaseHealth(int amount)
    {
        PlayerPrefs.SetInt(PLAYER_HEALTH, getHealth() - amount);
    }

    //Increase health, such as health packs.
    public static void increaseHealth(int amount)
    {
        PlayerPrefs.SetInt(PLAYER_HEALTH, getHealth() + amount);
        
        //prevents player health from exceeding 100
        if (PlayerPrefs.GetInt(PLAYER_HEALTH) > 100)
        {
            setHealth(100);
        }
    }

    //Get current scene from PlayerPrefs
    public static string getScene()
    {
        return PlayerPrefs.GetString(CURRENT_SCENE);
    }

    //Set the scene stored in PlayerPrefs
    public static void setScene(string sceneToSet)
    {
        PlayerPrefs.SetString(CURRENT_SCENE, sceneToSet);
    }

    //Gets the x, y, z coordinates of the player in PlayerPrefs and returns them as a Vector3.
    public static Vector3 getLocation()
    {
        float x = PlayerPrefs.GetFloat(PLAYER_X);
        float y = PlayerPrefs.GetFloat(PLAYER_Y);
        float z = PlayerPrefs.GetFloat(PLAYER_Z);
        Vector3 loc = new Vector3(x, y, z);
        return loc;
    }

    //Sets the location in PlayerPrefs.
    public static void setLocation(Vector3 loc)
    {
        PlayerPrefs.SetFloat(PLAYER_X, loc.x);
        PlayerPrefs.SetFloat(PLAYER_Y, loc.y);
        PlayerPrefs.SetFloat(PLAYER_Z, loc.z);
    }

    public static string getInventory()
    {
        return PlayerPrefs.GetString(INVENTORY);
    }

    public static void setInventory(string savedData)
    {
        PlayerPrefs.SetString(INVENTORY, savedData);
    }
}
