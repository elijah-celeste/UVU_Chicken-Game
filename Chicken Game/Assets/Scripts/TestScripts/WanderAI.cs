using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAI : MonoBehaviour {

	public float moveSpeed = 2.0f;
	void MoveForward(){
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 
	}
	void TurnOrientation(){
		int randomNum = Random.Range(0,360);
		transform.Rotate(0,randomNum,0);
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "CheckPoint"){
			TurnOrientation();
		}
		else{
			MoveForward();
		}
	}
}
