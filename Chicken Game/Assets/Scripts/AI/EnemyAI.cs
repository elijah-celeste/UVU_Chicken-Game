using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

	public enum state{
		Wandering,
		Following
	}

	public state _state;

	public Transform target;

	public GameObject _gameObject;
	NavMeshAgent nav;

	public float followSpeed = 6;

	void Awake () {
		nav = GetComponent<NavMeshAgent>();
		_state = state.Wandering;
		_gameObject = this.gameObject;
	}

	void Update(){
		switch(_state){
			case state.Wandering:
				_gameObject.gameObject.GetComponent<UnitWander>().Wander(nav);
				break;
			case state.Following:
				nav.speed = followSpeed;
				nav.SetDestination(target.position);
				nav.transform.LookAt(target);
				break;
		}
		
		// if(isWandering == true){
		// 	wander.gameObject.GetComponent<UnitWander>().Wander(nav);
		// }
	}
}
