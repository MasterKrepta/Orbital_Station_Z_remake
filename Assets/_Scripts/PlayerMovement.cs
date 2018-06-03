using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    [HideInInspector]
    Rigidbody rb;

    [HideInInspector]
    Vector3 movement = Vector3.zero;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        MovePlayer();
	}

    void GetInput() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement = new Vector3(h, 0, v);
    }

    private void MovePlayer() {
        rb.velocity = movement * moveSpeed;
        
    }
}
