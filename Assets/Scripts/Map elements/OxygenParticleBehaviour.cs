using UnityEngine;
using System.Collections;

public class OxygenParticleBehaviour : MonoBehaviour {

	public float VALUE = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position - new Vector3 (2 * Time.deltaTime, 0, 0);
		transform.position = transform.position + new Vector3 (0, 0.5f * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var playerScript = other.GetComponent<PlayerScript>();
		if (playerScript != null) {
			playerScript.GainOxygen (VALUE);
			GameObject.Destroy (gameObject);
		}
	}
}
