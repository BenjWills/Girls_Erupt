using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsState : BaseStates
{
    public override void EnterState(GameController gc)
    {
        Debug.Log("SS Entered");
    }
    public override void UpdateState(GameController gc)
    {
        if (gc.inSettings == false)
        {
            gc.mainMenu.SetActive(true);
            gc.settingsMenu.SetActive(false);
            gc.TransitionToState(gc.ms);
        }
    }
}
