using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void DeathActions();

    public static event DeathActions OnEnemyKilled;


    

    internal static void CallOnEnemyDeath() {
        if (OnEnemyKilled != null)
            OnEnemyKilled();
    }
}
