using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

	public enum state{
		wandering,
		following
	}

	public state _state;

	public Transform target;

	public GameObject _gameObject;
	NavMeshAgent nav;

	public float followSpeed = 6;
	public float currentSpeed;

	void Awake () {
		nav = GetComponent<NavMeshAgent>();
		_state = state.wandering;
		_gameObject = this.gameObject;
	}

	void Update(){
		switch(_state){
			case state.wandering:
				_gameObject.gameObject.GetComponent<UnitWander>().Wander(nav);
				break;
			case state.following:
				if(target.tag == "Chicken"){
					nav.speed = followSpeed + 8;
				}
				else{
					nav.speed = followSpeed;
				}
				nav.SetDestination(target.position);
				// nav.transform.LookAt(target);
				break;
		}

		currentSpeed = nav.speed;
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			GameManagement.health -= 25;
		}
		if(other.gameObject.tag == "Chicken"){
			other.gameObject.GetComponent<UnitHealth>().TakeDamage(1);
		}
	}
}
