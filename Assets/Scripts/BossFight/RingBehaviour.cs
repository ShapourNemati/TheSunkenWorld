using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RingBehaviour : MonoBehaviour, ICapturable {

	//The one who will be notified
	public PoseidonBehaviour poseidonBehaviour;

	// Use this for initialization
	void Start () {
		poseidonBehaviour = GameObject.Find ("Poseidon").GetComponent <PoseidonBehaviour>();
	}

	public void GetCaptured()
	{
		poseidonBehaviour.NotifyCapture ();
		Camera.main.GetComponent <RandomShake>().PlayShake ();
		GetComponent <FadeAway>().StartFading();
	}

	// Update is called once per frame
	void Update () {
		transform.position = transform.position - new Vector3 (2 * Time.deltaTime, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "RemoveGem") {
			GetComponent <FadeAway>().StartFading();
		}

	}
}
