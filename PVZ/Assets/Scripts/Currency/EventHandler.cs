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

}
