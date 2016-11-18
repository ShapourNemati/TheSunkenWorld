using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ProjectileBehaviour : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = transform.position + new Vector3 (speed * Time.deltaTime, 0, 0);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		var capturable = other.GetComponent<ICapturable> ();
		if (capturable != null) {
			capturable.GetCaptured ();
			GameObject.Destroy (gameObject);
		}
		//if enemy trap them and disable their attack
		//if player, ignore
		//if Poseidon deal damage?
		//should not be other cases
	}
}
