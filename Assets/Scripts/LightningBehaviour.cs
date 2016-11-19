using UnityEngine;
using System.Collections;

public class LightningBehaviour : MonoBehaviour {

	public float delay = 2f;

	public int DMG = 30;

	public BoxCollider2D myCollider;

	// Use this for initialization
	void Start () {

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
