using UnityEngine;
using System.Collections;

public class DamageTakenVisual : MonoBehaviour {

	public float duration = 0.25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;
		if (duration <= 0)
			GameObject.Destroy (gameObject);	
	}
}
