using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateFinalCorridor : GameState
{
    public GameStateFinalCorridor(StateManager stateManager) : base("FinalCorridor", stateManager)
    {

    }

    public override GameState GetState()
    {
        return base.GetState();
    }

    public override void OnEnter()
    {
        base.OnEnter();
        GameEventManager.MainMenuEvent += onGameComplete;
        Debug.Log("Entered Final Corridor");
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.MainMenuEvent -= onGameComplete;
        Debug.Log("Exited Final Corridor");
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.Alpha4))
        {
            onGameComplete();
        }

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void onGameComplete()
    {
        StateManager.SetNewState(StateManager.GameFinish);
    }
}
