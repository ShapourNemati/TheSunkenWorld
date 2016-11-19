using UnityEngine;
using System.Collections;

public class LightningBehaviour : MonoBehaviour {

	public float delay = 2f;

	public int DMG = 30;

	public BoxCollider2D myCollider;

	public AudioClip[] SoundEffects;

	// Use this for initialization
	void Start () {
		AudioSource Audio = GetComponent<AudioSource>();
		Audio.clip = SoundEffects[Random.Range(0, SoundEffects.Length-1)];
		Audio.Play();
	}

	// Update is called once per frame
	void Update () {

		delay -= Time.deltaTime;
		if (delay <= 0) {
			myCollider.enabled = true;
			if (delay <= -0.2f)
				GameObject.Destroy (gameObject);
		}
	
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		var playerScript = other.GetComponent<PlayerScript>();
		if (playerScript != null) {
			playerScript.TakeDamage (DMG);
			GameObject.Destroy (gameObject);
		}
	}
}
