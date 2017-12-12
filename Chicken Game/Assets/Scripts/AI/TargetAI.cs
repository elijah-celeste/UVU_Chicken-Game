using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetAI : MonoBehaviour {

	public enum state{
		wandering, inPen, caught, running
	}

	public state _state;

	public Transform enemy;
	public Transform holdingSpot;
	public Transform orientation;
	public Transform checkpoint;

	public GameObject _gameObject;
	public bool active = true;
	NavMeshAgent nav;

	public float runSpeed = 8f;

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
				InPen();
				break;
			case state.running:
				nav.speed = runSpeed;
				nav.SetDestination(enemy.transform.forward*25);
				break;
		}
	}

	void Holding(){
		transform.position = holdingSpot.position;
		transform.rotation = orientation.rotation;
	}

	void InPen(){
		transform.position = checkpoint.position;
		active = false;
	}
}