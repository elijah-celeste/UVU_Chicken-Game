using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour {
	public int currentHealth;
	public int maxHealth = 10;
	public Transform spawnPoint;
	public int points;

	void Start(){
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;
		if(currentHealth <= 0){
			currentHealth = 0;
			GameManagement.AddPoints(points);
			transform.position = spawnPoint.position;
			transform.rotation = spawnPoint.rotation;
			currentHealth = maxHealth;
		}
	}
}
