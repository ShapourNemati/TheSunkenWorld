using UnityEngine;
using System.Collections;

public class FollowPlayerNoGoingBack : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player.transform.position.x > gameObject.transform.position.x)
			transform.position = Vector3.Lerp(
				transform.position,
				player.transform.position + offset, .051f);

	}
}
