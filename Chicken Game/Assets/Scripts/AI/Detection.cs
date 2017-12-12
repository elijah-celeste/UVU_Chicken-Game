using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {
	public GameObject _gameObject;

	void OnTriggerEnter (Collider other) {
		if(_gameObject.gameObject.tag == "Enemy"){
			if(other.gameObject.tag == "Player"){
				_gameObject.GetComponent<EnemyAI>().target = other.transform;
			}
		}
		if(_gameObject.gameObject.tag == "Chicken"){

		}
		// if(other.gameObject.tag == "Player"){
		// 	if(_.gameObject.tag == "Chicken"){
		// 		//pass boolean isFleeing = true
		// 	}
		// 	if(_gameObject.gameObject.tag == "Enemy"){
		// 		//pass boolean isChasing = true
		// 		//pass chaseTarget = player
		// 		_gameObject.GetComponent<EnemyAI>().
		// 	}
		// }
		// if(other.gameObject.tag == "Chicken"){
		// 	if(this.gameObject.tag == "Enemy"){
		// 		//pass boolean isChasing = true
		// 		//pass chaseTarget = chicken
		// 	}
		// }
	}
}
