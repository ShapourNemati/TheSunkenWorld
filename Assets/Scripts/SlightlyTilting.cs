using UnityEngine;
using System.Collections;

public class SlightlyTilting : MonoBehaviour {

	bool clockWise = true;
	public const float DURATION = 1f;
	public const float SPEED = 0.6f;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 2*DURATION/3;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			clockWise = !clockWise;
			timer = DURATION;
		}

		transform.Rotate (new Vector3 (0, 0, SPEED * (clockWise ? 1 : -1)));
	}
}
