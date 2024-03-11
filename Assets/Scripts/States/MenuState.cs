using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class MenuState : BaseStates
{
    public override void EnterState(GameController gc)
    {
        Debug.Log("MS Entered");
        gc.iGMenu.SetActive(false);
        gc.mainMenu.SetActive(true);
        gc.inputManagerScript.enabled = false;
        gc.iGMenuSettings.enabled = false;

        foreach (CinemachineVirtualCamera camera in gc.cameras)
        {
            camera.Priority = 10;
        }
        gc.mainMenuCam.Priority = 11;
    }
    public override void UpdateState(GameController gc)
    {
        if (gc.isPlaying == true)
        {
            gc.TransitionToState(gc.gs);
        }

        if (gc.inSettings == true)
        {
            gc.mainMenu.SetActive(false);
            gc.settingsMenu.SetActive(true);
            gc.TransitionToState(gc.ss);
        }
    }
}
