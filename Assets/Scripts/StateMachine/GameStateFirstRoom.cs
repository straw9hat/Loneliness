using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateFirstRoom : GameState
{
    public GameStateFirstRoom(StateManager stateManager) : base("FirstRoom", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.FirstRoomEvent += onSecondRoomEnter;
        Debug.Log("Entered First Room");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.FirstRoomEvent -= onSecondRoomEnter;
        Debug.Log("Exited First Room");
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.Alpha1))
        {
            onSecondRoomEnter();
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void onSecondRoomEnter()
    {
        StateManager.SetNewState(StateManager.SecondRoom);
    }
}
