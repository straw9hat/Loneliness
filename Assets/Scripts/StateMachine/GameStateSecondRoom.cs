using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSecondRoom : GameState
{
    public GameObject[] room1Ghosts = new GameObject[3];
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
        room1Ghosts = GameObject.FindGameObjectsWithTag("RoomOneGhosts");
        foreach (GameObject obj in room1Ghosts)
        {
            Debug.Log(obj.name);
            //obj.gameObject.GetComponent<FollowPlayer>().enabled = false;
            //obj.gameObject.GetComponent<BoxCollider>().enabled = true;
            //obj.transform.localPosition = Vector3.MoveTowards(obj.transform.localPosition, new Vector3(25f, 14.25915f, -21f), 7 * Time.deltaTime);
            obj.gameObject.GetComponent<FollowPlayer>().trappedIn();
        }
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
        if (trapDoorTrigger.trapDoor2)
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
