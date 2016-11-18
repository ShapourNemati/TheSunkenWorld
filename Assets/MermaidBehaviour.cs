using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MermaidBehaviour : MonoBehaviour, ICapturable {

	public bool active = true;

	public void GetCaptured()
	{
		active = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (active)
			Debug.Log ("I'm harming the player. I swear");
		else
			Debug.Log ("Don't you worry don't you worry child");
	}

}
