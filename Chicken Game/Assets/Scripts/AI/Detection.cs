using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour {

	public bool targetLock = false;

	public GameObject _gameObject;

	void OnTriggerStay (Collider other) {
		if(targetLock == false){
			if(_gameObject.tag == "Enemy"){
				if(other.gameObject.tag == "Chicken"){
					if(other.gameObject.GetComponent<TargetAI>().active == true){
						setEnemyTargetFollow(other);
						targetLock = true;
					}
					else{
						targetLock = false;
					}
				}
				if(other.gameObject.tag == "Player"){
					setEnemyTargetFollow(other);
					targetLock = true;
				}
			}
			if(_gameObject.tag == "Chicken"){
				if(_gameObject.GetComponent<TargetAI>().active == true){
					if(_gameObject.GetComponent<TargetAI>()._state == TargetAI.state.wandering){
						if((other.gameObject.tag == "Player") || (other.gameObject.tag == "Enemy")){
							_gameObject.GetComponent<TargetAI>().enemy = other.transform;
							_gameObject.GetComponent<TargetAI>()._state = TargetAI.state.running;
						}
					}
				}	
			}
		}
	}
	void OnTriggerExit(Collider other){
		if(_gameObject.tag == "Enemy"){
			if((other.gameObject.tag == "Player") || (other.gameObject.tag == "Chicken")){
				_gameObject.GetComponent<EnemyAI>()._state = EnemyAI.state.wandering;
				targetLock = false;
			}
		}
		if(_gameObject.tag == "Chicken"){
			if(_gameObject.GetComponent<TargetAI>().active == true){
				if((other.gameObject.tag == "Player") || (other.gameObject.tag == "Enemy")){
					_gameObject.GetComponent<TargetAI>()._state = TargetAI.state.wandering;
				}
			}
		}
	}

	void setEnemyTargetFollow(Collider other){

		_gameObject.GetComponent<EnemyAI>().target = other.transform;
		_gameObject.GetComponent<EnemyAI>()._state = EnemyAI.state.following;
	}
}
