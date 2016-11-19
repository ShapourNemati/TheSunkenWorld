using UnityEngine;
using System.Collections;

public class TridentBehaviour : MonoBehaviour {

	Vector3 startingPosition;
	public float distance = 10f;
	public float speed = 10f;
	public float delay = 1f;
	bool moving = false;

	public int DMG = 10;

	public AudioClip[] SoundEffects;

	// Use this for initialization
	void Start () {
		startingPosition = transform.position;

		AudioSource Audio = GetComponent<AudioSource>();
		Audio.clip = SoundEffects[Random.Range(0, SoundEffects.Length)];
		Audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!moving) {
			delay -= Time.deltaTime;
			if (delay <= 0)
				moving = true;
		} else {
			transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
			if (transform.position.y - startingPosition.y >= distance) {
				GameObject.Destroy (gameObject);
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		var playerScript = other.GetComponent<PlayerScript>();
		if (playerScript != null) {
			playerScript.TakeDamage (DMG);
			GameObject.Destroy (gameObject);
		}
	}
}
