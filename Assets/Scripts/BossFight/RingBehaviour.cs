using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RingBehaviour : MonoBehaviour, ICapturable {

	//The one who will be notified
	public PoseidonBehaviour poseidonBehaviour;

	// Use this for initialization
	void Start () {
	}

	public void GetCaptured()
	{
		poseidonBehaviour.NotifyCapture ();
		GameObject.Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
