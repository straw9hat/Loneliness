using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateGameFinish : GameState
{
    public GameObject[] corridorGhosts = new GameObject[32];
    private GameObject door;
    public static bool lastGate = false;
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
        lastGate = true;
        Utils.FindIncludingInactive("MakePathColliders").gameObject.SetActive(true);
        corridorGhosts = GameObject.FindGameObjectsWithTag("CorridorGhosts");
        foreach (GameObject obj in corridorGhosts)
        {
            Debug.Log(obj.name);
            //obj.gameObject.GetComponent<FollowPlayer>().enabled = false;
            //obj.gameObject.GetComponent<BoxCollider>().enabled = true;
            GameObject.Destroy(obj.GetComponent<SpringJoint>());
            GameObject.Destroy(obj.GetComponent<Rigidbody>());
            Vector3 pos = new Vector3(-290f, -0.5f, 0.803f);
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, pos, 0.01f);
            //obj.transform.Translate(new Vector3(-283.9f, -0.5f, 0.803f)); 
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        GameEventManager.MainMenuEvent -= onGameRestart;
        Debug.Log("Game Restart");
        door = GameObject.Find("Door4Flow");
        door.GetComponent<DoorBehavior>().closeDoor();
    }

    public override void Update()
    {
        base.Update();
        foreach(GameObject obj in corridorGhosts)
        {
            Vector3 pos = new Vector3(-290f, -0.5f, 0.803f);
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, pos, 0.05f);
        }
        if (trapDoorTrigger.finsihLine)
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
        //SceneManager.LoadScene("SampleScene");
    }
}
