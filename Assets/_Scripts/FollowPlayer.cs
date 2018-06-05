using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour {
    NavMeshAgent agent;

    [SerializeField] Transform player;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.position);
	}
}
