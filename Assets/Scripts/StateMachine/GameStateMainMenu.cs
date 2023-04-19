using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMainMenu : GameState
{
    //private GameObject mainMenu;
    public GameStateMainMenu(StateManager stateManager) : base("MainMenu", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.MainMenuEvent += onFirstRoomEnter;
        Debug.Log("Entered Main Menu");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.MainMenuEvent -= onFirstRoomEnter;
        Debug.Log("Exited Main Menu");
    }

    public override void Update()
    {
        base.Update();
        if (Input.anyKey)
        {
            onFirstRoomEnter();
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void onFirstRoomEnter()
    {
        StateManager.SetNewState(StateManager.FirstRoom);
    }
}
