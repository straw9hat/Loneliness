using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateFinalCorridor : GameState
{
    public GameObject[] room1Ghosts = new GameObject[14];
    private GameObject door;
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
        door = GameObject.Find("Door3Flow");
        door.GetComponent<DoorBehavior>().closeDoor();
        room1Ghosts = GameObject.FindGameObjectsWithTag("RoomOneGhosts");
        
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
        if (movementTest.playCutscene)
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
