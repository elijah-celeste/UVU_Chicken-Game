using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour {

	public Transform target;
	public float moveSpeed = 2f;

	public Transform chickenPen;
	
	public Rigidbody enemy;

	public int points = 10;

	void OnTriggerStay(Collider other){
		if(other.gameObject.name == "Player"){
			Debug.Log("Player has entered chicken's trigger");
			
			moveSpeed = 5f;
			transform.LookAt(target.transform);
			transform.Translate(Vector3.back*moveSpeed*Time.deltaTime);
			
		}
		else{
			moveSpeed = 2f;

		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Player"){
			if(other.gameObject.name == "Player"){
				//Add points to a score.
				ScoreManager.AddPoints(points);
				transform.position = chickenPen.position;
				transform.rotation = chickenPen.rotation;
			}
		}
	}
	
	// Update is called once per frame
	// void FixedUpdate () {
	// 		transform.LookAt(target);
	// 		transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);
		
		
	// }
}
