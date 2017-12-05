using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPoint : MonoBehaviour {

	public Transform target;
	public bool pointAtTarget = true;

	void Update () {
		// We set a boolean to decide whether or not we want to point at or away from the target.
		if(pointAtTarget == false)
		// Multiply the transform.position of the object this script is attached to, minus the target's position.
		transform.LookAt(2 * transform.position - target.position);
		else{
			transform.LookAt(target);
		}
	}
}
