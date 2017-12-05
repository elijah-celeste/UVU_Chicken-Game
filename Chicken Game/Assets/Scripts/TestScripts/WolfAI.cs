using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour {
	public Transform target;
	public float runSpeed = 5f;
	public float walkSpeed = 2f;
	public Rigidbody enemy;
	
	public GameObject pcHealth;
	public int damage;

	void OnTriggerStay(Collider other){
		if(other.gameObject.name == "Player"){
			// Debug.Log("Player has entered wolf's trigger");
			transform.LookAt(target.transform);
			transform.Translate(Vector3.forward*runSpeed*Time.deltaTime);	
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Player"){
			var hit = other.gameObject;
			// var health = hit.GetComponent<PlayerHealth>();
			print ("Wolf is attacking!");

			if(pcHealth != null){
				pcHealth.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
			}
		}
	}
}