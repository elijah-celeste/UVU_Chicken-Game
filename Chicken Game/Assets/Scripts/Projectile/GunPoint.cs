using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPoint : MonoBehaviour {
	public Transform target;
	void Update () {
		transform.LookAt(target);
	}
}
