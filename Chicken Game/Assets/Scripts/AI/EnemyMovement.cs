using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	Transform target;
	NavMeshAgent nav;
	public bool followActive = false;
	public bool wanderActive = true;

	public float followSpeed = 6;
	public float wanderSpeed = 3;

	public float wanderRadius;
	public float wanderTimer;

	private Transform wanderTarget;
	private float timer;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent>();
	}

	void Update(){
		if (followActive==true){
			nav.speed = followSpeed;
			nav.SetDestination (player.position);
			nav.transform.LookAt(player);
		}
		if (wanderActive==true){
			timer += Random.Range(1.0f,timer) * Time.deltaTime;
			nav.speed = wanderSpeed;

			if(timer>=wanderTimer){
				Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
				nav.SetDestination(newPos);
				timer = 0;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			GameManagement.health -= 10;
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
