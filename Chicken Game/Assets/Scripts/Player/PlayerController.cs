using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "Chicken"){
			if(other.gameObject.GetComponent<TargetAI>().active == true){
				other.gameObject.GetComponent<TargetAI>()._state = TargetAI.state.caught;
			}
		}
		
	}
}
