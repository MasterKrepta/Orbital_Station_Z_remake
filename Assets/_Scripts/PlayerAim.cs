using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {

    [SerializeField]
    float rotSpeed = 2f;
    [HideInInspector] float h;
    float v;
    Vector3 rot;

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update() {
        GetInput();
        AimPlayer();
    }

    private void GetInput() {
        h = Input.GetAxis("H_Aim");
        v = Input.GetAxis("V_Aim");
        rot = new Vector3(h, v, 0);
    }

    private void AimPlayer() {
        //TODO This needs smoothing/refactored for keyboard input
        Vector3 lookDir = new Vector3(h, 0, v);
        if (lookDir == Vector3.zero)
            return;
        transform.rotation = Quaternion.LookRotation(lookDir);
    }

 
}
