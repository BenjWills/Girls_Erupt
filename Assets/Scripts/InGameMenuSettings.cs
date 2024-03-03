using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuSettings : MonoBehaviour
{
    public InputManagerScript inputManagerScript;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public bool settingsOpen;
    public bool isPaused = false;

    public void OpenSettingsMenu()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        settingsOpen = true;
    }

    public void CloseSettingsMenu()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        settingsOpen = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        isPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        mainMenu.SetActive(false);
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        isPaused = true;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
