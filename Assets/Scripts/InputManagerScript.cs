using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public InGameMenuSettings iGMenuSettings;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused == true && iGMenuSettings.settingsOpen == false)
        {
            Time.timeScale = 0f;
            mainMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else if (isPaused == false && iGMenuSettings.settingsOpen == false)
        {
            Time.timeScale = 1f;
            mainMenu.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }

    public void PauseUnpause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;
    }
}
