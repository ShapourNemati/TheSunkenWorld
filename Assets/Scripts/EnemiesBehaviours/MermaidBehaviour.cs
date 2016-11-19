using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MermaidBehaviour : MonoBehaviour, ICapturable {

	public const int DMG = 10;
	public bool active = true;
	public float speed = 7;

	public GameObject bubble;
	public AudioClip[] SoundEffects;

	public void GetCaptured()
	{
		active = false;
		bubble.SetActive (true);
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
		if (active)
			transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0, 0);
		else
			transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (active) {
			var playerScript = other.GetComponent<PlayerScript>();
			if (playerScript != null) {
				playerScript.TakeDamage (DMG);
				//TODO: fade instead of disappearing instantly
				GameObject.Destroy (gameObject);
			}
		}
	}

}
