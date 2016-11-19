using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LightingsStrikes : MonoBehaviour, ISkill {

	public GameObject Lightning;
	public float offset = 15;

	public void Cast()
	{
		Vector3 playerPos = GameObject.Find ("Player").transform.position;


		//leftlightning
		Vector3 targetPos = new Vector3(-offset, playerPos.y, playerPos.z);
		GameObject.Instantiate (Lightning, targetPos, Quaternion.identity);


		//middle lightning
		targetPos = playerPos;
		GameObject.Instantiate (Lightning, targetPos, Quaternion.identity);

		//right lightning
		targetPos = new Vector3(offset, playerPos.y, playerPos.z);
		GameObject.Instantiate (Lightning, targetPos, Quaternion.identity);

	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
}
