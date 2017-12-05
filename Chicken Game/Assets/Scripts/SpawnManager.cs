﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	public void Spawn () {
		int spawnPointIndex = Random.Range (0,spawnPoints.Length);

		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
