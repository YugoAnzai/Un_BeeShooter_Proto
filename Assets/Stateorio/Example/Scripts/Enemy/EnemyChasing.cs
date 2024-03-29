﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// State in which enemy goes after the player.
/// If you look at this state in the FsmCore component of the enemy,
/// you will see it has two transition rules, one of which has a larger priority.
/// This is important, if enemy doesn't see the player, he shouldn't be able to attack him.
/// </summary>
[RequireComponent (typeof (IPlayerGetter))]
public class EnemyChasing : FsmState {

	public override string StateName => "EnemyChasing";

	public Transform Player;
	public float speed = 3;

	[SerializeField] private NavMeshAgent agent;
	private Vector3 lastKnownLoc;

	void Awake () {
		if(Player == null)
			Player = GetComponent<IPlayerGetter>().GetPlayer().transform;
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = lastKnownLoc = Player.position;
	}

	public override void OnStateEnter()
	{
		agent.speed = speed;
	}

	public override void OnStateLeave () {
		agent.ResetPath ();
	}

	public Vector3 GetLastKnownPlayerLocation() {
		return lastKnownLoc;
	}
}
