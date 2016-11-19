using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class FlipYourAss : MonoBehaviour, ISkill {


	bool active = false;
	float duration = 2f;

	public void Cast() {
		GameObject.Instantiate (this);
	}

	// Use this for initialization
	void Start () {
		active = true;
		GameObject.Find ("Player").transform.Rotate (new Vector3(0,180,0));
		GameObject.Find ("Player").GetComponent<PlayerScript> ().InvertControls (true);
	}

	// Update is called once per frame
	void Update () {
		if (active)
			duration -= Time.deltaTime;
		if (duration <= 0) {
			GameObject.Find ("Player").transform.Rotate (new Vector3(0,-180,0));
			GameObject.Find ("Player").GetComponent<PlayerScript> ().InvertControls (false);
			GameObject.Destroy (gameObject);
		}


	}
}
