using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Whether the enemy sees the player.
/// Since the calculations of this conditions can be slow,
/// it implements FsmCondPolled to reduce the number of calls to expensive operations.
/// This doesn't affect the gameplay by much, but it does save valuable CPU power.
/// </summary>
[RequireComponent (typeof (IPlayerGetter))]
public class SeesPlayer : FsmCondPolled {

	public float fieldOfView;
	public float sightRange;
	public LayerMask layerMask;

	public Transform Player;

	public bool drawGizmo;
	public Color gizmoColor;

	private float sightRangeSqr;

	void Awake() {
		sightRangeSqr = sightRange * sightRange;

		if (Player == null)
			Player = GetComponent<IPlayerGetter>().GetPlayer().transform;
	}

	// Use this for initialization
	void Start() {
		StartEvals ();
	}

	private bool distanceOk(Vector3 toPlayer) {
		return toPlayer.sqrMagnitude <= sightRangeSqr;
	}

	private bool angleOk(Vector3 toPlayer) {
		float angle = Vector3.Angle (transform.forward, toPlayer);
		return angle <= fieldOfView / 2.0f;
	}

	private bool rayOk(Vector3 toPlayer) {
		bool oldSetting = Physics.queriesHitTriggers;
		Physics.queriesHitTriggers = false;

		RaycastHit hitInfo;
		bool ret = Physics.Raycast (transform.position, toPlayer, out hitInfo, toPlayer.magnitude, layerMask) && 
			hitInfo.collider != null && hitInfo.collider.gameObject.CompareTag("Player");

		Physics.queriesHitTriggers = oldSetting;

		return ret;
	}

	protected override bool EvaluateCondition () {
		Vector3 toPlayer = Player.position - transform.position;
		return distanceOk (toPlayer) && angleOk (toPlayer) && rayOk (toPlayer);
	}

	#if UNITY_EDITOR
	private void OnDrawGizmos()
	{

		if (!drawGizmo)
			return;

		Handles.color = gizmoColor;
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, fieldOfView/2, sightRange);
		Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, -fieldOfView/2, sightRange);

	}
	#endif

}
