using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSecondRoom : GameState
{
    public GameStateSecondRoom(StateManager stateManager) : base("SecondRoom", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.MainMenuEvent += onThirdRoomEnter;
        Debug.Log("Entered Second Room");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.MainMenuEvent -= onThirdRoomEnter;
        Debug.Log("Exited Second Room");
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.Alpha2))
        {
            onThirdRoomEnter();
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void onThirdRoomEnter()
    {
        StateManager.SetNewState(StateManager.ThirdRoom);
    }
}
