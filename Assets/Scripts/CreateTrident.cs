using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class CreateTrident : MonoBehaviour, ISkill {

	public GameObject Trident;

	public void Cast()
	{
		Vector3 playerPos = GameObject.Find ("Player").transform.position;
		Vector3 targetPos = new Vector3 (playerPos.x, -7, playerPos.z);
		GameObject.Instantiate (Trident, targetPos, Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
