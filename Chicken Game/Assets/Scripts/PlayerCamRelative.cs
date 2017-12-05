using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamRelative : MonoBehaviour {

	public Transform pointer;

	public CharacterController controller;
	public Transform myCamera;

	public float moveSpeed = 5.0f;
	public float gravity = 14.0f;
	public float jumpHeight = 10.0f;
	float verticalVelocity;
	
	Vector3 inputDirection = new Vector3(0,0,0);
	Vector3 moveDirection = new Vector3(0,0,0);

	float horizontal;
	float vertical;



	void Start(){
		controller = GetComponent<CharacterController>();
	}

	void Update () {
		
		//movement relative to camera
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		inputDirection = new Vector3 (horizontal,0,vertical);

		Vector3 cameraForward = myCamera.forward;
		cameraForward.y = 0;

		Quaternion cameraRelativeRotation = Quaternion.FromToRotation (Vector3.forward, cameraForward);
		Vector3 lookToward = cameraRelativeRotation * inputDirection;
		if (inputDirection.sqrMagnitude>0){
			Ray lookRay = new Ray (transform.position, lookToward);
			transform.LookAt (lookRay.GetPoint(1));
		}

		if(controller.isGrounded){
			verticalVelocity = -gravity * Time.deltaTime;
			if(Input.GetKeyDown(KeyCode.Space)){
				verticalVelocity = jumpHeight;
			}
		}
		else{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		Vector3 moveVertical = new Vector3(0,verticalVelocity,0);
		moveDirection = transform.forward * moveSpeed * inputDirection.sqrMagnitude;

		controller.Move ((moveDirection + moveVertical) * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.Mouse0)){
		//rotate Player to face pointer
			Vector3 point = pointer.position;
			point.y = 0.0f;
			transform.LookAt(point);
		}
	}
}
