using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateThirdRoom : GameState
{
    public GameObject[] room1Ghosts = new GameObject[6];
    private GameObject door;
    private GameObject player;
    //private GameObject pullingObj;
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
        door = GameObject.Find("Door2Flow");
        door.GetComponent<DoorBehavior>().closeDoor();
        room1Ghosts = GameObject.FindGameObjectsWithTag("RoomOneGhosts");
        foreach (GameObject obj in room1Ghosts)
        {
            Debug.Log(obj.name);
            //obj.gameObject.GetComponent<FollowPlayer>().enabled = false;
            //obj.gameObject.GetComponent<BoxCollider>().enabled = true;
            //obj.transform.localPosition = Vector3.MoveTowards(obj.transform.localPosition, new Vector3(25f, 14.25915f, -21f), 7 * Time.deltaTime);
            obj.gameObject.GetComponent<FollowPlayer>().trappedIn();
        }
        player = GameObject.Find("Player");
        Utils.FindInChildrenIncludingInactive(player, "PullingObj").SetActive(false);
        Utils.FindInChildrenIncludingInactive(player, "PushingObj").SetActive(true);
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
