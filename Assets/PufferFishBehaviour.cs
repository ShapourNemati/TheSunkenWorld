using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PufferFishBehaviour : MonoBehaviour, ICapturable {

	public const int DMG = 25;
	public bool active = true;

	public void GetCaptured()
	{
		//active = false;
		// do nothing, PufferFish pops the bubbles
		Debug.Log ("The pufferfish pops the bubble!");
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
