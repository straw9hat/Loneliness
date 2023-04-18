using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager
{
    public static event UnityAction MainMenuEvent;
    public static event UnityAction FirstRoomEvent;
    public static event UnityAction SecondRoomEvent;
    public static event UnityAction ThirdRoomEvent;
    public static event UnityAction FinalCorridorEvent;
    public static event UnityAction GameFinishEvent;


    public static void OnMainMenu()
    {
        MainMenuEvent?.Invoke();
    }

    public static void OnFirstRoom()
    {
        FirstRoomEvent?.Invoke();
    }

    public static void OnSecondRoom()
    {
        SecondRoomEvent?.Invoke();
    }

    public static void OnThirdRoom()
    {
        ThirdRoomEvent?.Invoke();
    }

    public static void OnFinalCorridor()
    {
        FinalCorridorEvent?.Invoke();
    }

    public static void OnGameFinish()
    {
        GameFinishEvent?.Invoke();
    }
}
