using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour {

	public Vector3 pos;
	public Quaternion rot;
	public Vector3 scale;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = pos;
		transform.rotation = rot;
		transform.localScale = scale;
	}
}
