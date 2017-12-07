using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetAI : MonoBehaviour {

	public Transform holdingSpot;
	public Transform orientation;

	public GameObject wander;
	NavMeshAgent nav;

	public bool isCaught = true;
	public bool inPen = false;
	public bool isWandering = true;

	void Awake(){
		nav = GetComponent<NavMeshAgent>();
	}

	void Update () {
		Holding();
		if(isWandering==true){
			// pass run Wander(); from UnitWander.cs
			// wander.Wander(nav);
			wander.gameObject.GetComponent<UnitWander>().Wander(nav);
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			isCaught = true;
		}

	}

	void Holding(){
		if (isCaught == true && inPen == false){
			transform.position = holdingSpot.position;
			transform.rotation = orientation.rotation;
		}
		if (inPen == true){
			// set transform to pen checkpoint
		}
	}
}