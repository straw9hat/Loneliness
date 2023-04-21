using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class GameStateMainMenu : GameState
{
    //private GameObject mainMenu;
    private GameObject door;
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
        door = GameObject.Find("Door4Flow");
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
        Vector3 pos = door.transform.localPosition;
        pos.z = -0.45f;
        door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, pos, 4);
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
