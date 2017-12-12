using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCheckpoint : MonoBehaviour {

	public int chickenCount;

	public Transform[] spawnPoint;

	void Awake(){
		chickenCount = 0;
	}

	void OnTriggerStay (Collider other) {
		if(other.gameObject.tag == "Chicken"){
			if(other.gameObject.GetComponent<TargetAI>()._state == TargetAI.state.caught){
				other.gameObject.GetComponent<TargetAI>().checkpoint = spawnPoint[chickenCount];
				other.gameObject.GetComponent<TargetAI>()._state = TargetAI.state.inPen;
				chickenCount++;
				GameManagement.AddPoints(25);			
			}
		}
	}

	void Update(){
		if(chickenCount>=5){
			GameManagement.AddPoints(65);
			chickenCount = 0;
		}
	}
}
