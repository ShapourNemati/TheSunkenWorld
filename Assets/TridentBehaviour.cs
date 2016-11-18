using UnityEngine;
using System.Collections;

public class TridentBehaviour : MonoBehaviour {

	Vector3 startingPosition;
	public float distance = 10f;
	public float speed = 10f;
	public float delay = 1f;
	bool moving = false;

	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!moving) {
			delay -= Time.deltaTime;
			if (delay <= 0)
				moving = true;
		} else {
			transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);
			if (transform.position.y - startingPosition.y >= distance) {
				GameObject.Destroy (gameObject);
			}
		}

	}
}
