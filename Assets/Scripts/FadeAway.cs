using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour {

	public float duration = .5f;
	private bool fading = false;

	// Use this for initialization
	void Start () {
	
	}

	public void StartFading()
	{
		fading = true;
	}

	// Update is called once per frame
	void Update () {
		if (fading) {
			duration -= Time.deltaTime;

			Color c = GetComponentInChildren<SpriteRenderer> ().color;
			c.a = duration;
			GetComponentInChildren<SpriteRenderer> ().color = c;

			if (duration <= 0)
				GameObject.Destroy (gameObject);
		}
	}
}
