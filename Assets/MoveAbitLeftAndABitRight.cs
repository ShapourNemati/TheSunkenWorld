using UnityEngine;
using System.Collections;

public class MoveAbitLeftAndABitRight : MonoBehaviour {
	public float UPPER_LIMIT = 1f;
	public float LOWER_LIMIT = -1f;
	public float speed = 0;
	public bool up = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);
		if (up) {
			speed += Time.deltaTime;
			if (speed >= UPPER_LIMIT)
				up = false;
		} else {
			speed -= Time.deltaTime;
			if (speed <= LOWER_LIMIT)
				up = true;
		}
	}
}
