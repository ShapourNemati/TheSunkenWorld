﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PoseidonBehaviour : MonoBehaviour {


	public class TestSkill : ISkill {
		public void Cast()
		{
			Debug.Log ("A spell is being cast");
		}
	}

	public GameObject text;

	int rings = 5;

	public GameObject [] attacksObjs;
	ISkill[] attacks;
	public float timeBetweenAttacks = 5f;
	float timer = 0;

	public GameObject[] timedSpawnersObj;
	public GameObject[] triggerSpawnersObj;
	TimedSpawner[] timedSpawners;
	TriggerSpawner[] triggerSpawners;

	public AudioClip[] SoundEffects;
	AudioSource Audio;

	private bool attackAnimationIsOff = true;
	private bool doubleTheFun= false;

	// Use this for initialization
	void Start () {
		timer = timeBetweenAttacks;
		Audio = GetComponent<AudioSource>();
		Audio.clip = SoundEffects[0];

		attacks = new ISkill[attacksObjs.Length];
		for (int i = 0; i < attacksObjs.Length; i++) {
			attacks [i] = attacksObjs [i].GetComponent <ISkill> ();	
		}

		timedSpawners = new TimedSpawner[timedSpawnersObj.Length];
		for (int i = 0; i < timedSpawnersObj.Length; i++) {
			timedSpawners [i] = timedSpawnersObj [i].GetComponent<TimedSpawner> ();
		}

		triggerSpawners = new TriggerSpawner[triggerSpawnersObj.Length];
		for (int i = 0; i < triggerSpawnersObj.Length; i++) {
			triggerSpawners [i] = triggerSpawnersObj [i].GetComponent<TriggerSpawner> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if ((timer <= 0.45) && (attackAnimationIsOff)) {
			//Change stance
			GetComponentInChildren <Animator>().SetTrigger ("Attack");
			attackAnimationIsOff = false;
		}
		if (timer <= 0) {
			//pick a random skill
			ISkill s = attacks [(int)(Random.value * attacks.Length)];

			//Roll the dice, sex or no?
			int RandomNr = 0;// Random.Range(0, 10);
			if (RandomNr == 0) {
				Audio.Play();
			}

			//cast the spell
			s.Cast ();
			if (doubleTheFun) {
				//pick a random skill
				s = attacks [(int)(Random.value * attacks.Length)];
				//cast the spell
				s.Cast ();
			}
			timer = timeBetweenAttacks;
			attackAnimationIsOff = true;
		}
	}

	public void NotifyCapture()
	{
		rings--;

		switch (rings) {
		case 4:
			//increment skill rate by 20%
			timeBetweenAttacks=4f;
			text.GetComponent<Text>().text = "Gems: 1/5";
			break;
		case 3:
			//spawn a wave of enemies
			//done by activating a trigger spawner
			foreach (TriggerSpawner ts in triggerSpawners) {
				ts.Spawn ();
			}
			text.GetComponent<Text>().text = "Gems: 2/5";
			break;
		case 2:
			//send two skills at a time
			doubleTheFun = true;
			text.GetComponent<Text>().text = "Gems: 3/5";
			break;
		case 1:
			//continuous spawn of enemies
			//done by activating some inactive timed spawners
			foreach (TimedSpawner ts in timedSpawners) {
				ts.enabled = true;
			}
			text.GetComponent<Text>().text = "Gems: 4/5";
			break;
		case 0:
			text.GetComponent<Text>().text = "Gems: 5/5";
			//You won!
			//Time to choose: are you with Poseidon or against him?
			Debug.Log ("YOU WON THE GAME. Gj dude, gj");
				SceneManager.LoadScene("_Ending");
			break;
		}
	}
}
