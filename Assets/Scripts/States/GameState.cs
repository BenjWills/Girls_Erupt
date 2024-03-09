using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class GameState : BaseStates
{
    public override void EnterState(GameController gc)
    {
        gc.inputManagerScript.SetActive(true);
        gc.iGMenuSettings.enabled = true;
        foreach (CinemachineVirtualCamera camera in gc.cameras)
        {
            camera.Priority = 10;
        }
        gc.gameCam.Priority = 11;
    }
    public override void UpdateState(GameController gc)
    {
        
    }
}
