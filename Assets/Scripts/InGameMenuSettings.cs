using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuSettings : MonoBehaviour
{
    public InputManagerScript inputManagerScript;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public bool settingsOpen;

    public void OpenSettingsMenu()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        settingsOpen = true;
    }

    public void CloseSettingsMenu()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        settingsOpen = false;
    }

    public void ResumeGame()
    {
        inputManagerScript.isPaused = false;
    }
}
