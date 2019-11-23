using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string PLAYER_HEALTH = "player_health";

    private const string PLAYER_LIVES = "player_lives";

    private const string CURRENT_SCENE = "current_scene";

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
}
