using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GravityAttack : MonoBehaviour , ISkill{

	bool active = false;
	float duration = 2f;
	float intensity = 10f;

	public void Cast() {
		GameObject.Instantiate (this);
	}

	// Use this for initialization
	void Start () {
		active = true;
		GameObject.Find ("Player").GetComponent<Rigidbody2D>().AddForce(Physics.gravity * intensity);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (duration);
		if (active)
			duration -= Time.deltaTime;
		if (duration <= 0) {
			Debug.Log ("About to destroy");
			GameObject.Find ("Player").GetComponent<Rigidbody2D>().AddForce(-Physics.gravity * intensity);
			GameObject.Destroy (gameObject);
		}


	}
}
