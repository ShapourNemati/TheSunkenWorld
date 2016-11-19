using UnityEngine;
using System.Collections;

public class ActivateSpawners : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		TriggerSpawner SpawnerScript = other.GetComponent<TriggerSpawner>();
		if (SpawnerScript != null) {
			SpawnerScript.Spawn ();
		}
	}
}

