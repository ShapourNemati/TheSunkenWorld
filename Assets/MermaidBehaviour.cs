using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MermaidBehaviour : MonoBehaviour, ICapturable {

	public const int DMG = 10;
	public bool active = true;

	public void GetCaptured()
	{
		active = false;
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
