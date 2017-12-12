using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {
	public GameObject _gameObject;

	void OnTriggerEnter (Collider other) {
		if(_gameObject.gameObject.tag == "Enemy"){
			if(other.gameObject.tag == "Player"){
				setEnemyTargetFollow(other);
			}
			if(other.gameObject.tag == "Chicken"){
				setEnemyTargetFollow(other);
			}
		}
		if(_gameObject.gameObject.tag == "Chicken"){
			
		}
	}
	void OnTriggerExit(Collider other){
		if((other.gameObject.tag == "Player") || (other.gameObject.tag == "Chicken")){
			if(_gameObject.tag == "Enemy"){
				_gameObject.GetComponent<EnemyAI>()._state = EnemyAI.state.Wandering;
			}
		}
	}

	void setEnemyTargetFollow(Collider other){
		_gameObject.GetComponent<EnemyAI>().target = other.transform;
		_gameObject.GetComponent<EnemyAI>()._state = EnemyAI.state.Following;
	}
}
