using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	public Vector3 cameraOffset;
	public float CameraMoveSpeed = 120.0f;
	public GameObject CameraFollow;
	public float clampAngle = 50.0f;
	public float inputSensitivity = 150.0f;
	public float mouseX;
	public float mouseY;
	private float rotY = 0.0f;
	private float rotX = 0.0f;

	void Start(){
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update(){
		mouseX = Input.GetAxis("MouseX");
		mouseY = Input.GetAxis("MouseY");

		rotY += mouseX * inputSensitivity * Time.deltaTime;
		rotX += mouseY * inputSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
		transform.rotation = localRotation;
	}

	void LateUpdate(){
		CameraUpdater();
	}
	void CameraUpdater(){
		Transform target = CameraFollow.transform;
		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
