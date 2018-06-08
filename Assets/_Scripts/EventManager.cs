using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void DeathActions();

    public static event DeathActions OnEnemyKilled;
    public static event DeathActions OnGameOver;




    internal static void CallOnEnemyDeath() {
        if (OnEnemyKilled != null)
            OnEnemyKilled();
    }

    internal static void CallOnGameOver() {
        if(OnGameOver != null) {
            OnGameOver();
        }
    }
}
