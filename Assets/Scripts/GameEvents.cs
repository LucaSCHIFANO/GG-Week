using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static UnityEvent tiltLeft = new UnityEvent();
    public static UnityEvent tiltRight = new UnityEvent();
    public static UnityEvent hasNotArduino = new UnityEvent();

    public static UnityEvent sceneIsLoaded = new UnityEvent();
}
