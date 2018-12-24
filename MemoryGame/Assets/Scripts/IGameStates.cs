using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStates
{
    void OnStateEnter(GameObject gO);
    void ExecuteState(GameObject button, int x, int y);
}
