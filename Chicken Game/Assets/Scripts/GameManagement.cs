using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

	public static int score;
	public static int health;
	public static int ammo;

	public Text healthDisplay;
	public Text scoreDisplay;
	public Text ammoDisplay;

	void Awake () {
		score = 0;
		health = 100;
		ammo = 32;
	}

	void Update(){
		scoreDisplay.text = "Score: " + score;
		healthDisplay.text = "Health: " + health;
		ammoDisplay.text = "Ammo: " + ammo + "/" + "32";

		if(score<0){
			score = 0;
		}
		if(ammo<0){
			ammo = 32;
		}
		if(health<0){
			health = 100;
		}
		
	}

	//possibly use an enumerator?
	public static void AddPoints(int pointsToAdd){
		score += pointsToAdd;
	}
	public static void DecreaseAmmo(int ammoRemove){
		ammo -= ammoRemove;
	}
	public static void HealthModifier(int hp){
		health += hp;
	}
}
