using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetAI : MonoBehaviour {

	public enum state{
		inPen, wandering, caught, running
	}

	public state _state;

	public Transform holdingSpot;
	public Transform orientation;
	public Transform checkpoint;

	public GameObject _gameObject;
	NavMeshAgent nav;

	void Awake(){
		nav = GetComponent<NavMeshAgent>();
		_state = state.wandering;
	}

	void Update () {
		switch(_state){
			case state.wandering:
				_gameObject.GetComponent<UnitWander>().Wander(nav);
				break;
			case state.caught:
				Holding();
				break;
			case state.inPen:
				transform.position = checkpoint.position;
				break;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			if(_state != state.inPen)
			_state = state.caught;
		}
	}

	void Holding(){
			transform.position = holdingSpot.position;
			transform.rotation = orientation.rotation;
	}
}