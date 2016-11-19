using UnityEngine;
using System.Collections;

public class plato : MonoBehaviour {
	public AudioClip[] SoundEffects;
	private AudioSource Audio;

	// Use this for initialization
	void Start () {
		Audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!Audio.isPlaying) {
			int RandomNr = Random.Range(0, SoundEffects.Length);
			Debug.Log(RandomNr);
			Audio.clip = SoundEffects[RandomNr];
			Audio.Play();
		}
	}
}
