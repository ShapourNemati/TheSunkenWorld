using UnityEngine;
using System.Collections;

public class TriggerSpawner : MonoBehaviour {

	public GameObject creature;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn()
	{
		GameObject.Instantiate (creature,transform.position,Quaternion.identity);
	}
}
