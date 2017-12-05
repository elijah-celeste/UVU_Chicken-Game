using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "Player"){
			if(this.gameObject.tag == "Chicken"){
				//pass boolean isFleeing = true
			}
			if(this.gameObject.tag == "Enemy"){
				//pass boolean isChasing = true
				//pass chaseTarget = player
			}
		}
		if(other.gameObject.tag == "Chicken"){
			if(this.gameObject.tag == "Enemy"){
				//pass boolean isChasing = true
				//pass chaseTarget = chicken
			}
		}
	}
}
