using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IThirdState : MonoBehaviour,IGameStates
{
    private GameManagerScriptGM gM;
    private GuiScriptGM gui;

    public void ExecuteState(GameObject button, int x, int y)
    {
    }

    public void OnStateEnter(GameObject gO)
    {
        gM = gO.GetComponent<GameManagerScriptGM>();
        gui = gO.GetComponent<GuiScriptGM>();

        gM.Check(gui);
    }
}
