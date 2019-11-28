using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    
    private Vector3 resetPos = new Vector3(0, 0, -1);

    //When the retry button is clicked, go to the last level but with full health
    public void ButtonClick()
    {
        PlayerPrefsManager.setLives(3);
        PlayerPrefsManager.setHealth(100);
        Cursor.visible = false;
        //TODO: Set a proper location based off a level instead of forcing 0, 0, -1.
        PlayerPrefsManager.setLocation(resetPos);
        SceneManager.LoadScene(PlayerPrefsManager.getScene());
    }
}
