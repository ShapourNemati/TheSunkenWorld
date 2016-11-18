using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);

	}
}
