using UnityEngine;
using System.Collections;

public class ScrollToRight : MonoBehaviour {

	public Vector3 startingPosition;
	public float speed = .5f;
	public float distance = 100-18f;

	public float distanceLeft;

	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
		distanceLeft = distance;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = transform.position +
			-new Vector3 (speed * Time.deltaTime, 0, 0);
		distanceLeft -= Time.deltaTime * speed;
		if (distanceLeft <= 0) {
			transform.position = startingPosition;
			distanceLeft = distance;
		}

	}
}
