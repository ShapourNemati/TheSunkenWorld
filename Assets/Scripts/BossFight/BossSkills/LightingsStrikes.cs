using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LightingsStrikes : MonoBehaviour, ISkill {

	public GameObject Lightning;
	public float offset = 15;
	public GameObject warning;

	public void Cast()
	{
		Vector3 playerPos = GameObject.Find ("Player").transform.position;


		//leftlightning
		//Vector3 targetPos = new Vector3(-offset, playerPos.y, playerPos.z);
		//GameObject.Instantiate (Lightning, targetPos, Quaternion.identity);


		//middle lightning
		Vector3 targetPos = playerPos;
		GameObject.Instantiate (Lightning, targetPos, Quaternion.identity);

		GameObject o = (GameObject) GameObject.Instantiate (warning, new Vector3 (targetPos.x, 4.5f, targetPos.z), Quaternion.identity);
		GameObject.Destroy (o, 1.5f);

		//right lightning
		//targetPos = new Vector3(offset, playerPos.y, playerPos.z);
		//GameObject.Instantiate (Lightning, targetPos, Quaternion.identity);

	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
}
