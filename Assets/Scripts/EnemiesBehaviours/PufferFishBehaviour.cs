﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PufferFishBehaviour : MonoBehaviour, ICapturable {


	public GameObject myParticleSystem;

	public const int DMG = 15;
	public bool active = true;
	float UPPER_LIMIT = 7f;
	float LOWER_LIMIT = -7f;
	public float speed = 0;
	public bool up = true;
	public bool vertical = false;


	public AudioClip[] SoundEffects;

	public void GetCaptured()
	{
		//active = false;
		// do nothing, PufferFish pops the bubbles
		Debug.Log ("The pufferfish pops the bubble!");
	}


	// Use this for initialization
	void Start () {
		myParticleSystem.SetActive (false);
		AudioSource Audio = GetComponent<AudioSource>();
		Audio.clip = SoundEffects[Random.Range(0, SoundEffects.Length)];
		int RandomNr = Random.Range(0, 3);
		if (RandomNr == 0) {
			Audio.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (vertical)
			transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
		else
			transform.position = transform.position + new Vector3 (speed * Time.deltaTime,0, 0);
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
				//TODO: fade instead of disappearing instantly
				Explode ();
			}
		}
	}

	void Explode() {
		myParticleSystem.SetActive (true);
		var exp = GetComponentInChildren<ParticleSystem>();
		exp.Play();
		GetComponentInChildren <SpriteRenderer>().enabled = false;
		Destroy(gameObject, exp.duration);
	}
}
