using UnityEngine;
using System.Collections;

public class LightningBehaviour : MonoBehaviour {

	float delay = 1.5f;

	public int DMG = 30;

	public BoxCollider2D myCollider;

	public AudioClip[] SoundEffects;

	public GameObject[] imgs;

	// Use this for initialization
	void Start () {
		AudioSource Audio = GetComponent<AudioSource>();
		Audio.clip = SoundEffects[Random.Range(0, SoundEffects.Length)];
		Audio.Play();
	}

	// Update is called once per frame
	void Update () {

		delay -= Time.deltaTime;
		if (delay <= 0) {
			myCollider.enabled = true;
			foreach (GameObject o in imgs) {
				o.SetActive (true);
				Camera.main.GetComponent <RandomShake>().PlayShake ();
			}
			if (delay <= -.5f)
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
