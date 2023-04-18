using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameStateMainMenu MainMenu;
    public GameStateFirstRoom FirstRoom;
    public GameStateSecondRoom SecondRoom;
    public GameStateThirdRoom ThirdRoom;
    public GameStateFinalCorridor FinalCorridor;
    public GameStateGameFinish GameFinish;

    protected GameState CurState;

    private void Awake()
    {
        // initialize SDV player states here
        MainMenu = new GameStateMainMenu(this);
        FirstRoom = new GameStateFirstRoom(this);
        SecondRoom = new GameStateSecondRoom(this);
        ThirdRoom = new GameStateThirdRoom(this);
        FinalCorridor = new GameStateFinalCorridor(this);
        GameFinish = new GameStateGameFinish(this);
    }

    // Start is called before the first frame update
    protected void Start()
    {
        CurState = GetInitialState();
        if (CurState != null)
        {
            CurState.OnEnter();
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        if (CurState != null)
        {
            CurState.Update();
            UpdateAnimator();
        }
    }

    public void SetNewState(GameState NewState)
    {
        CurState.OnExit();
        CurState = NewState;
        CurState.OnEnter();
    }

    // will be defined in child classes aka mini games' state machines
    protected GameState GetInitialState()
    {
        return MainMenu;
    }

    public void OnEnable()
    {
        GameEventManager.FirstRoomEvent += dummy;

    }

    public void OnDisable()
    {
        GameEventManager.FirstRoomEvent -= dummy;
    }

    protected void UpdateAnimator()
    {
    }

    public GameState GetCurrentState()
    {
        return CurState;
    }
    private void dummy()
    {

    }
}
