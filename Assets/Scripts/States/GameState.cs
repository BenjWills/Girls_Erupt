using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

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
        gc.phoneUI.SetActive(true);
    }
    public override void UpdateState(GameController gc)
    {

    }
}
