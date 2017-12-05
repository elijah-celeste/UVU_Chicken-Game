using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float moveSpeed = 10;
	public float turnSpeed;
	public float jumpHeight;


	void FixedUpdate(){

		var j = Input.GetAxis("Jump")* Time.deltaTime*jumpHeight;
		var i = Input.GetAxis("Horizontal")* Time.deltaTime*moveSpeed;
		var z = Input.GetAxis("Vertical")* Time.deltaTime*moveSpeed;
		var y = Input.GetAxis("Rotate")* Time.deltaTime*turnSpeed;

		transform.Rotate(0,y,0);
		transform.Translate(0,0,z);
		transform.Translate(0,j,0);
		transform.Translate(i,0,0);
	}

		// if (Input.GetKeyDown(KeyCode.Mouse0)){
        //     Fire();
        // }
	}

	// Fire a Bullet
	// public GameObject bulletPrefab;
	// public Transform bulletspawn;

	// void Fire(){
	// 	var bullet = (GameObject)Instantiate(
	// 		bulletPrefab,
	// 		bulletspawn.position,
	// 		bulletspawn.rotation);
	// 	bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward*20;
	// 	Destroy(bullet,2.0f);
	// }