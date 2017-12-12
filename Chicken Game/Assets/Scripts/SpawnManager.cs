using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject _gameObject;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;


	public Vector3 Spawn () {
		int spawnPointIndex = Random.Range (0,spawnPoints.Length);
		return spawnPoints[spawnPointIndex].position;
		// Instantiate (_gameObject, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
