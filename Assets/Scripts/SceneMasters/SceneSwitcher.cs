using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
	public string NewScene;
	public KeyCode Button;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(Button)) {
			SceneManager.LoadScene(NewScene);
		}
	}
}
