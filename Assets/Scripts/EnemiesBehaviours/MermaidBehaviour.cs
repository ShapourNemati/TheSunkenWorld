using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MermaidBehaviour : MonoBehaviour, ICapturable {

	public const int DMG = 20;
	public bool active = true;
	public float speed = 7;

	public AudioClip[] SoundEffects;

	public void GetCaptured()
	{
		active = false;
	}

	// Use this for initialization
	void Start () {
		AudioSource Audio = GetComponent<AudioSource>();
		Audio.clip = SoundEffects[Random.Range(0, SoundEffects.Length - 1)];
		int RandomNr = Random.Range(0, 3);
		if (RandomNr == 0) {
			Audio.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0, 0);
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
