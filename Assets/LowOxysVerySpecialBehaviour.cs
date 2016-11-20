using UnityEngine;
using System.Collections;

public class LowOxysVerySpecialBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + new Vector3 (0, 1* Time.deltaTime, 0);
	}
}
