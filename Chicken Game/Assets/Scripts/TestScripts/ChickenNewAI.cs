using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ChickenNewAI : MonoBehaviour {

	public Transform target;
	public float runSpeed = 2f;

	public Transform chickenPen;
	
	public Rigidbody enemy;

	public int points = 10;

    //Wander VAR
    public float wanderSpeed = 5;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 30;

    CharacterController controller;
    float heading;
    Vector3 targetRotation;


// Wandering Functions
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);
        StartCoroutine(NewHeading());
    }
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    /// Calculates a new direction to move towards.
    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }

	void OnTriggerStay(Collider other){
		if(other.gameObject.name == "Player"){
			Debug.Log("Player has entered chicken's trigger");
			
			runSpeed = 5f;
			transform.LookAt(target.transform);
			transform.Translate(Vector3.back*runSpeed*Time.deltaTime);
			
		}
		else{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
            var forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * wanderSpeed);

		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "Player"){
			if(other.gameObject.name == "Player"){
				//Add points to a score.
				ScoreManager.AddPoints(points);
				transform.position = chickenPen.position;
				transform.rotation = chickenPen.rotation;
			}
		}
	}
}
