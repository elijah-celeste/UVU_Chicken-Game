﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

	public void PlayGame () {
		SceneManager.LoadScene(1);
	}

	public void LevelExit(){
		Debug.Log("Game has closed.");
		Application.Quit();
	}
}