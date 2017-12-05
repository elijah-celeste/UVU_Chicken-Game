using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHop : MonoBehaviour {	
	public float jumpSpeed = 0.2f;
	public Rigidbody rb;

	public float waitTime = 2f;
	float timer;

	void Start(){
		rb = GetComponent <Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			timer += Time.deltaTime;
			if (timer > waitTime){
				rb.AddForce(Vector3.up * jumpSpeed);
				timer = 0f;
			}

	}
}