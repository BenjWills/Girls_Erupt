using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameState : BaseStates
{
    public override void EnterState(GameController gc)
    {
        Debug.Log("GS Entered");

        gc.iGMenu.SetActive(true);
        gc.mainMenu.SetActive(false);
        gc.allCanvas.SetActive(false);
        

        foreach (CinemachineVirtualCamera camera in gc.cameras)
        {
            camera.Priority = 10;
        }
        gc.gameCam.Priority = 11;

        gc.inputManagerScript.enabled = true;
        gc.iGMenuSettings.enabled = true;
        gc.phoneUI.enabled = true;
    }
    public override void UpdateState(GameController gc)
    {
        if (gc.isPlaying == false)
        {
            gc.TransitionToState(gc.ms);
        }
    }
}
