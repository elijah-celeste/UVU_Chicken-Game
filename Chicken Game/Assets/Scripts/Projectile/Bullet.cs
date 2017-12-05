using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int damage = 1;
	public int time = 2;

	public GameObject hitParticle;

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyBullet());
	}

	void OnCollisionEnter(Collision other){
		var hit = other.gameObject;
		var health = hit.GetComponent<UnitHealth>();

		if(other.gameObject.tag == "Enemy"){
			hitParticle = Instantiate(hitParticle,transform.position,transform.rotation);
			Destroy(hitParticle, 2.0f);
		}

		if(health != null){
			health.TakeDamage(damage);
		}
		Destroy(gameObject);
	}

	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
