using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public const float SPRINT_COST = 10f;
	public const float SHOOT_COST = 10f;
	public const float SPRINT_SPEED = 30f;
	public const float SPRINT_DURATION = 0.2f;
	public const float BASE_SPEED = 5f;

	public float speed = BASE_SPEED ;
	public OxygenManager oxy;

	public GameObject projectile;

	public int health = 100;

	private bool sprinting = false;
	private float sprintingTimer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		HandleInput ();
		if (sprinting) {
			sprintingTimer -= Time.deltaTime;
			transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);
			if (sprintingTimer <= 0) {
				sprinting = false;
				speed = BASE_SPEED;
			}
		}
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
		if (!sprinting) {
			// Movement
			if (Input.GetKey (KeyCode.A))
				transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0, 0);
			if (Input.GetKey (KeyCode.S))
				transform.position = transform.position - new Vector3 (0, speed * Time.deltaTime, 0);
			if (Input.GetKey (KeyCode.D))
				transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);
			if (Input.GetKey (KeyCode.W))
				transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
		}
		//Skills

		//Sprint
		if (Input.GetKeyDown (KeyCode.J))
		{
			//Check Oxygen
			if (oxy.PayOxygenCost (SPRINT_COST)) {
				//If oxygen is good, sprint
				sprinting = true;
				speed = SPRINT_SPEED;
				sprintingTimer = SPRINT_DURATION;
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
