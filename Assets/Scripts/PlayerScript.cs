using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public const float SPRINT_COST = 10f;
	public const float SHOOT_COST = 10f;

	public float speed = 3;
	public OxygenManager oxy;

	public GameObject projectile;

	public int health = 100;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		HandleInput ();
		CheckDead ();

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//if enemy decrease health
		//if our own projectile, ignore
		//should not be other cases
	}

	void CheckDead()
	{
		if (health <= 0) {
			//reload level?
		}
	}

	void HandleInput()
	{
		// Movement
		if (Input.GetKey (KeyCode.A))
			transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0, 0);
		if (Input.GetKey (KeyCode.S))
			transform.position = transform.position - new Vector3 (0, speed * Time.deltaTime, 0);
		if (Input.GetKey (KeyCode.D))
			transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);
		if (Input.GetKey (KeyCode.W))
			transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);

		//Skills

		//Sprint
		if (Input.GetKeyDown (KeyCode.J))
		{
			//Check Oxygen
			if (oxy.PayOxygenCost (SPRINT_COST)) {
				//If oxygen is good, sprint
				transform.position = transform.position + new Vector3 (speed * Time.deltaTime * 10, 0, 0);
			} else {
				//TODO: give the user some actual feedback
				Debug.Log ("Not enough oxygen");
			}

		}

		//Shoot
		if (Input.GetKeyDown (KeyCode.K))
		{
			//Check Oxygen
			if (oxy.PayOxygenCost (SPRINT_COST)) {
				//If oxygen is good, shoot
				GameObject.Instantiate (projectile);
			} else {
				//TODO: give the user some actual feedback
				Debug.Log ("Not enough oxygen");
			}
		}

			
	}
}
