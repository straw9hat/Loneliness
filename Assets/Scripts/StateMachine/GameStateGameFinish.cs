using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGameFinish : GameState
{
    public GameStateGameFinish(StateManager stateManager) : base("GameFinish", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.MainMenuEvent += onGameRestart;
        Debug.Log("Game Finish");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.MainMenuEvent -= onGameRestart;
        Debug.Log("Game Restart");
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.Alpha5))
        {
            onGameRestart();
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void onGameRestart()
    {
        StateManager.SetNewState(StateManager.MainMenu);
    }
}
