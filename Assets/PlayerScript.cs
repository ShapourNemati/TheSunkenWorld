using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	float speed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		HandleInput ();

	}

	void HandleInput()
	{
		// Movement
		if (Input.GetKey (KeyCode.A))
			transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0, 0);
		if (Input.GetKey (KeyCode.S))
			transform.position = transform.position - new Vector3 (0, speed * Time.deltaTime, 0);
		if (Input.GetKey (KeyCode.D))
			transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);
		if (Input.GetKey (KeyCode.W))
			transform.position = transform.position + new Vector3 (0, speed * Time.deltaTime, 0);

		//Skills

		//Sprint
		if (Input.GetKey (KeyCode.J))
		{
			//Check Oxygen
			//If oxygen is good, sprint
		}

		//Shoot
		if (Input.GetKey (KeyCode.J))
		{
			//Check Oxygen
			//If oxygen is good, shoot
		}

			
	}
}
