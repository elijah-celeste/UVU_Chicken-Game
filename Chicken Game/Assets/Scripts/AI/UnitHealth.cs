﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour {
	public int currentHealth;
	public int maxHealth = 10;
	public GameObject spawner;
	// public Transform spawnPoint;
	public int points;

	void Awake(){
		currentHealth = maxHealth;
	}

	public void TakeDamage(int amount){
		currentHealth -= amount;
		if(currentHealth <= 0){
			currentHealth = 0;
			GameManagement.AddPoints(points);
			spawner.GetComponent<SpawnManager>().Spawn();
			// transform.position = spawnPoint.position;
			// transform.rotation = spawnPoint.rotation;
			// currentHealth = maxHealth;
			Destroy(gameObject);
		}
	}
}
