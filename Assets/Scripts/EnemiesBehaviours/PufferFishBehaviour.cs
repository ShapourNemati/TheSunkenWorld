﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PufferFishBehaviour : MonoBehaviour, ICapturable {

	public const int DMG = 25;
	public bool active = true;
	public float UPPER_LIMIT = 1f;
	public float LOWER_LIMIT = -1f;
	public float speed = 0;
	public bool up = true;

	public void GetCaptured()
	{
		//active = false;
		// do nothing, PufferFish pops the bubbles
		Debug.Log ("The pufferfish pops the bubble!");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
		if (up) {
			speed += Time.deltaTime;
			if (speed >= UPPER_LIMIT)
				up = false;
		} else {
			speed -= Time.deltaTime;
			if (speed <= LOWER_LIMIT)
				up = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (active) {
			var playerScript = other.GetComponent<PlayerScript>();
			if (playerScript != null) {
				playerScript.TakeDamage (DMG);
			}
		}
	}
}