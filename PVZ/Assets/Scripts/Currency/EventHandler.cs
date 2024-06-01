using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public static class EventHandler
{
    public static event Action GameStartCameraMoveEvent;
    public static void GameStartCameraMove()
    {
        GameStartCameraMoveEvent?.Invoke();
    }

    public static event Action ChooseEndCameraMoveEvent;
    public static void ChooseEndCameraMove()
    {
        ChooseEndCameraMoveEvent?.Invoke();
    }

    public static event Action GameStartEvent;
    public static void GameStart()
    {
        GameStartEvent?.Invoke();
    }
    public static event Action ZombieIsCommingEvent;
    public static void ZombieIsComming()
    {
        ZombieIsCommingEvent?.Invoke();
    }
    public static event Action GameOverEvent;
    public static void GameOver()
    {
        GameOverEvent?.Invoke();
    }
    public static event Action DiffficultyChooseEndEvent;
    public static void DiffficultyChooseEnd()
    {
        DiffficultyChooseEndEvent.Invoke();
    }
    public static event Action<float> GameEventTimeSet;
    public static void GameEventTime(float time)
    {
        GameEventTimeSet.Invoke(time);
    }



}
