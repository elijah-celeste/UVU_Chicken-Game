using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shootPoint;
	public int shootSpeed;
	public GameObject manager;

	// public GameObject player;
	// public Transform pointer;
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			if (GameManagement.ammo > 0){
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(projectile,shootPoint.position,shootPoint.rotation);

			clone.velocity = shootPoint.TransformDirection(Vector3.forward*shootSpeed);

			GameManagement.DecreaseAmmo(1);
			}

		// //rotate Player to face pointer
		// 	Vector3 point = pointer.position;
		// 	point.y = 0.0f;
		// 	player.transform.LookAt(point);
		}
	}
}
