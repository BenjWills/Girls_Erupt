using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject mainMenu;
    private bool settingsOpen;
    [SerializeField] private GameObject settingsMenu;
    private MenuSettings menuSettingsScript;

    private void Start()
    {
        settingsOpen = false;

        if (settingsOpen == true)
        {
            settingsMenu = GameObject.Find("SettingsCanvas");
        }
        mainMenu = GameObject.Find("MainCanvas");
        menuSettingsScript = GameObject.Find("DontDestroy").GetComponent<MenuSettings>();
    }

    //This is called when the slider value is changed
    public void TextSliderSize()
    {
        for (int i = 0; i < menuSettingsScript.textList.Count; i++)
        {
            menuSettingsScript.textList[i].fontSize = menuSettingsScript.defaultTextSize[i] * menuSettingsScript.sliderValue;
        }
    }

    //This is called when the dropdown is changed
    public void FontStyleDropdown()
    {
        for (int i = 0; i < menuSettingsScript.textList.Count; i++)
        {
            menuSettingsScript.currentFont = menuSettingsScript.fontSelection[menuSettingsScript.currentFontNumb];
            menuSettingsScript.currentFontNumb = menuSettingsScript.dropdown.value;
        }
    }

    //This is called when the settings button is pressed
    public void SettingsButtonPressed()
    {
        settingsOpen = !settingsOpen;

        if (settingsOpen == false)
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    //This is called when play button is pressed
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Game");
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    //This is called when the quit button is pressed
    public void QuitButtonPressed()
    {
        Debug.Break();
        Application.Quit();
    }
}
