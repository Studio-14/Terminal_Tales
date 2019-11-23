using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{

    //When the retry button is clicked, go to the last level but with full health
    public void ButtonClick()
    {
        PlayerPrefsManager.setLives(3);
        PlayerPrefsManager.setHealth(100);
        SceneManager.LoadScene(PlayerPrefsManager.getScene());
    }
}
