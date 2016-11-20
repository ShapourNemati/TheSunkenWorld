using UnityEngine;
using System.Collections;

public class DamageTakenVisual : MonoBehaviour {

	public float duration = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		duration -= Time.deltaTime;

		Color c = GetComponent<SpriteRenderer> ().color;
		c.a = duration;
		GetComponent<SpriteRenderer> ().color = c;

	}
}
