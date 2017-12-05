using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAI : MonoBehaviour {

	public Transform holdingSpot;
	public Transform orientation;

	public bool isCaught = true;
	public bool inPen = false;

	void Update () {
		holding();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			isCaught = true;
		}

	}

	void holding(){
		if (isCaught == true && inPen == false){
			transform.position = holdingSpot.position;
			transform.rotation = orientation.rotation;
		}
	}
}