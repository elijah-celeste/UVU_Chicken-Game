using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitWander : MonoBehaviour {

	NavMeshAgent nav;

	public float wanderSpeed = 3;
	public float wanderRadius = 20;
	public float wanderTimer = 5;

	private float timer;

	public void Wander (NavMeshAgent thisObject) {
		nav = thisObject;
		timer += Random.Range(1.0f,timer) * Time.deltaTime;
		nav.speed = wanderSpeed;

		if(timer>=wanderTimer){
			Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
			nav.SetDestination(newPos);
			timer = 0;
		}
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask){
		Vector3 randDirection = Random.insideUnitSphere * dist;
		randDirection += origin;
		NavMeshHit navMeshHit;
		NavMesh.SamplePosition(randDirection, out navMeshHit, dist, layermask);
		return navMeshHit.position;
	}
}
