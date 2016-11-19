using UnityEngine;
using System.Collections;

public class SharkBehaviour : MonoBehaviour {

	public const int DMG = 50;
	public bool active = true;
	public float horizontalSpeed = 10f;

	public float UPPER_LIMIT = 1f;
	public float LOWER_LIMIT = -1f;
	public float verticalSpeedCounter = 0;
	public bool up = true;
	public float verticalSpeed = 5;

	public void GetCaptured()
	{
		active = false;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position - new Vector3 (horizontalSpeed * Time.deltaTime, 0, 0);

		if (up) {
			verticalSpeedCounter += Time.deltaTime;
			if (verticalSpeedCounter >= UPPER_LIMIT) {
				up = false;
				verticalSpeed = -1 * verticalSpeed;
			}
		} else {
			verticalSpeedCounter -= Time.deltaTime;
			if (verticalSpeedCounter <= LOWER_LIMIT) {
				up = true;
				verticalSpeed = -1 * verticalSpeed;
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
