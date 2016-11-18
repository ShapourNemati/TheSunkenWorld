using UnityEngine;
using System.Collections;

public class OxygenParticleBehaviour : MonoBehaviour {

	public float VALUE = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
