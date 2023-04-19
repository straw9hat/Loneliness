using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateThirdRoom : GameState
{
    public GameStateThirdRoom(StateManager stateManager) : base("ThirdRoom", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.MainMenuEvent += onFinalCorridorEnter;
        Debug.Log("Entered Third Room");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.MainMenuEvent -= onFinalCorridorEnter;
        Debug.Log("Exited Third Room");
    }

    public override void Update()
    {
        base.Update();
        if (trapDoorTrigger.trapDoor3)
        {
            onFinalCorridorEnter();
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void onFinalCorridorEnter()
    {
        StateManager.SetNewState(StateManager.FinalCorridor);
    }
}
