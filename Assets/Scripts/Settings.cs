using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Dropdown qualityDropdown;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    private void Start()
    {
        //Sets values of objects based off existing settings
        volumeSlider.value = PlayerPrefsManager.getVolume();
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
        fullscreenToggle.isOn = Screen.fullScreen;
        
        //Populates the array with resolution options.
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        
        //For loop that adds the resolutions as a string to a list as a string that the dropdown can use
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        
        //Adds the list to the dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //Changes volume of the audio mixer
    public void changeVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefsManager.setVolume(volume);
    }

    //Sets graphic quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Sets resolution for the game
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Makes the game fullscreen or windowed
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    //Returns to title screen
    public void SaveAndQuit()
    {
        SceneManager.LoadScene("0_Title");
    }

    //Deletes all game data and reloads settings menu
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
