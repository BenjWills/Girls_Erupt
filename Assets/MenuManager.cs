using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainCanvas;
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _settingsCanvas;

    private bool isPaused;

    private void Start()
    {
        _mainCanvas.SetActive(true);
        _settingsCanvas.SetActive(false);
        _pauseCanvas.SetActive(false);

        isPaused = false;

        if (InputManager.instance.MenuOpenCloseInput)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }
    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        OpenSettingsMenu();
    }
    private void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        CloseAllMenus();
    }

    private void OpenSettingsMenu()
    {
        _mainCanvas.SetActive(false);
        _settingsCanvas.SetActive(false);
        _pauseCanvas.SetActive(true);
    }
    private void CloseAllMenus()
    {
        _mainCanvas.SetActive(true);
        _settingsCanvas.SetActive(false);
        _pauseCanvas.SetActive(false);
    }
}
