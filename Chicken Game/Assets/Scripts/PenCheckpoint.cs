using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCheckpoint : MonoBehaviour {

	public int chickenCount;

	public Transform[] spawnPoint;

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "Chicken"){
			other.gameObject.GetComponent<TargetAI>()._state = TargetAI.state.inPen;
			// other.gameObject.GetComponent<TargetAI>().checkpoint = spawnPoint;
		}
	}
}
