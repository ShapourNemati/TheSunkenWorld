using UnityEngine;
using System.Collections;

public class IfYouLoveItThenYouShouldHavePutARingOnIt : MonoBehaviour {

	public float cooldown = 5f;
	public GameObject ring;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldown-=Time.deltaTime;
		if (cooldown <= 0) {
			SpawnARing ();
			cooldown = 5f + Random.Range (0, 3);
		}
	}

	public void SpawnARing()
	{
		GameObject.Instantiate (ring);
	}
}
