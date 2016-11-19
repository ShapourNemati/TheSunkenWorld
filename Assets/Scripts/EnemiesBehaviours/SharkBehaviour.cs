using UnityEngine;
using System.Collections;

public class SharkBehaviour : MonoBehaviour {

	public GameObject target;

	public const int DMG = 20;
	public bool active = true;
	public float horizontalSpeed = 10f;

	private float delta = .3f;

	public float verticalSpeed = 5;
	public float BASE_VERTICAL_SPEED = 5;

	public AudioClip[] SoundEffects;

	private bool dontFollow = false;
	private float dontFollowTimer;
	public const float DONT_FOLLOW_BASE_TIMER = .3f;

	public void GetCaptured()
	{
		active = false;
	}


	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player");
		AudioSource Audio = GetComponent<AudioSource>();
		Audio.clip = SoundEffects[Random.Range(0, SoundEffects.Length - 1)];
		int RandomNr = Random.Range(0, 3);
		if (RandomNr == 0) {
			Audio.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position - new Vector3 (horizontalSpeed * Time.deltaTime, 0, 0);

		if (!dontFollow) {
			if ((target.transform.position.y < transform.position.y) &&
			    (Mathf.Abs (target.transform.position.y - transform.position.y) > delta)) {
				verticalSpeed = -1 * BASE_VERTICAL_SPEED;
			} else if ((target.transform.position.y > transform.position.y) &&
			           (Mathf.Abs (target.transform.position.y - transform.position.y) > delta)) { 
				verticalSpeed = BASE_VERTICAL_SPEED;
			} else {
				verticalSpeed = 0;
				dontFollow = true;
				dontFollowTimer = DONT_FOLLOW_BASE_TIMER;
			}
		} else {
			dontFollowTimer -= Time.deltaTime;
			if (dontFollowTimer <= 0) {
				dontFollow = false;
			}
		}
		transform.position = transform.position + new Vector3 (0, verticalSpeed * Time.deltaTime, 0);
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
