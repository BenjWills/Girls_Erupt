using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool settingsOpen;
    public GameObject settingsMenu;
    public GameObject mainMenu;
    private MenuSettings menuSettingsScript;

    private void Start()
    {
        settingsOpen = false;

        if (settingsOpen == true)
        {
            settingsMenu = GameObject.Find("SettingsCanvas");
        }
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
            menuSettingsScript.currentFontNumb = menuSettingsScript.fontDropdown.value;
        }
    }

    //This is called when the settings button is pressed
    public void SettingsButtonPressed()
    {
        if (settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else if(mainMenu.activeSelf)
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
