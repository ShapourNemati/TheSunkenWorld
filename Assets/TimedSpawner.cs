using UnityEngine;
using System.Collections;

public class TimedSpawner : MonoBehaviour {

	public GameObject creature;
	public const float TIME_FOR_SPAWN = 5f;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = TIME_FOR_SPAWN;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			GameObject.Instantiate (creature,transform.position,Quaternion.identity);
			timer = TIME_FOR_SPAWN;
		}
	}
}
