﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public const float SPRINT_COST = 20f;
	public const float SHOOT_COST = 10f;
	public const float SPEED_COST = 25f;
	public const float SPEED_MULTIPLIER = 6f;
	public const float SPRINT_SPEED = 14f;
	public const float SPRINT_DURATION = 0.2f;
	public const float BASE_SPEED = 5f;

	public GameObject lowOxy;
	public GameObject retryText;

	public GameObject hitVisual;

	public GameObject confusedSprite;

	public float speed = BASE_SPEED ;
	public OxygenManager oxy;

	public GameObject projectile;
	public GameObject ProjectileSpawnLocation;

	public int health = 100;

	private bool sprinting = false;
	private float sprintingTimer = 0f;

	private bool accelerated = false;
	private bool invertedControls = false;

	private Slider healthSlider;

	public AudioClip[] SoundEffects;
	private AudioSource Audio;

	// Use this for initialization
	void Start () {
		healthSlider = GameObject.Find ("HealthSlider").GetComponent <Slider> ();
		Audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Random.Range(0,240) == 0) {
			Audio.clip = SoundEffects[Random.Range(0, SoundEffects.Length - 1)];
			Audio.Play();
		}

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

	public void GainOxygen(float amount)
	{
		oxy.oxygen += amount;
		Debug.Log ("Oxygen gained: " + amount + ". Current: " + oxy.oxygen); 
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//if enemy decrease health
		//if our own projectile, ignore
		//should not be other cases
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		healthSlider.value = health;
		GameObject.Instantiate (hitVisual, transform.position, Quaternion.identity);
		CheckDead ();
	}

	void CheckDead()
	{
		if (health <= 0 && this.enabled) {
			retryText.SetActive (true);
			transform.Rotate (new Vector3(0,0,180));
			this.enabled = false;
		}
	}

	void HandleInput()
	{
		if (!sprinting) {
			if (!invertedControls) {
				// Movement
				if (Input.GetKey (KeyCode.A))
					transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0, 0);
				if (Input.GetKey (KeyCode.S))
					transform.position = transform.position - new Vector3 (0, speed * Time.deltaTime, 0);
				if (Input.GetKey (KeyCode.D))
					transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);
				if (Input.GetKey (KeyCode.W))
					transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
			} else {
				if (Input.GetKey (KeyCode.A))
					transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);
				if (Input.GetKey (KeyCode.S))
					transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
				if (Input.GetKey (KeyCode.D))
					transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0, 0);
				if (Input.GetKey (KeyCode.W))
					transform.position = transform.position - new Vector3 (0, speed * Time.deltaTime, 0);
				
			}
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
				GameObject.Instantiate (lowOxy, gameObject.transform.position, Quaternion.identity);
			}

		}

		//Shoot
		if (Input.GetKeyDown (KeyCode.K))
		{
			//Check Oxygen
			if (oxy.PayOxygenCost (SPRINT_COST)) {
				//If oxygen is good, shoot
				GameObject.Instantiate (projectile, ProjectileSpawnLocation.transform.position, Quaternion.identity);
			} else {
				GameObject.Instantiate (lowOxy, gameObject.transform.position, Quaternion.identity);
			}
		}

		//IncreaseSpeed
		if (Input.GetKey (KeyCode.L)) {
			//Check Oxygen
			if (oxy.PayOxygenCost (SPRINT_COST * Time.deltaTime)) {
				//If oxygen is good, shoot
				accelerated = true;
				speed = SPEED_MULTIPLIER;
			} else {	
				GameObject.Instantiate (lowOxy, gameObject.transform.position, Quaternion.identity);
			}
		} else {
			if (accelerated) {		
				speed = BASE_SPEED;
				accelerated = false;
			}
		}
			
	}

	public void InvertControls (bool newState)
	{
		invertedControls = newState;
		confusedSprite.SetActive (newState);
	}
}
