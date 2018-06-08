using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OpenDoor : MonoBehaviour {


    float triggers;
    GameObject player;
    Animator anim;

    
    private void Awake() {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        anim = GetComponent<Animator>();
    }

    void GetInput() {
        triggers = Input.GetAxis("Triggers");
    }

    private void Update() {
        GetInput();
    }

    private void Open() {
        anim.SetBool("isOpen", true);
    }

    private void OnTriggerStay(Collider other) {
        
            if (other.gameObject == player && triggers > 0) {
                Open();
            }
        
            
    }

    private void OnTriggerExit(Collider other) {
        
            if (other.gameObject == player) {
                anim.SetBool("isOpen", false);
            }
        
    }

}

